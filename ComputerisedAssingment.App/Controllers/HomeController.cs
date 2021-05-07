using AutoMapper;
using ComputerisedAssingment.App.Models;
using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ComputerisedAssingment.App.Controllers
{
    public class HomeController : Controller
    {
        private iUsersInterface _usersInterface;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public HomeController(iUsersInterface usersInterface, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _usersInterface = usersInterface;
            _httpContextAccessor = httpContextAccessor;
        }


        #region login


        [HttpGet]
        public IActionResult Login(string? msg)
        {
            TempData["AlertMsg"] = msg;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UsersVM model)
        {
            if (ModelState.IsValid)
            {
                Users userdetails = await _usersInterface.Login(model.UniqueId, model.Password);
                if (userdetails != null)
                {

                    //session 
                    UsersVM newLoginCred = new UsersVM()
                    {
                        Id = userdetails.Id,
                        UniqueId = userdetails.UniqueId,
                        Email = userdetails.Email,
                        FullName = userdetails.FullName,
                        UserType = userdetails.UserType

                    };
                    //var value = JsonConvert.DeserializeObject(_session.GetString("LoginCred"));//get session value
                    //session
                    if (newLoginCred.UserType == 1) // student  
                    {
                        _session.SetString("LoginCred", JsonConvert.SerializeObject(newLoginCred));
                        _session.SetString("LoginCredUniqueId", JsonConvert.SerializeObject(newLoginCred.UniqueId));
                        return RedirectToAction("Upload", "Student", new { area = "" });
                    }
                    if (newLoginCred.UserType == 0) //  teacher 
                    {
                        _session.SetString("LoginCred", JsonConvert.SerializeObject(newLoginCred));
                        _session.SetString("LoginCredUniqueId", JsonConvert.SerializeObject(newLoginCred.UniqueId));
                        return RedirectToAction("Upload", "Teacher", new { area = "" });
                    }
                    if (newLoginCred.UserType == 2) // admin 
                    {
                        _session.SetString("LoginCred", JsonConvert.SerializeObject(newLoginCred));
                        _session.SetString("LoginCredUniqueId", JsonConvert.SerializeObject(newLoginCred.UniqueId));
                        return RedirectToAction("AssingStudents", "Admin", new { area = "" });
                    }

                    return RedirectToAction("", "Dashboard");
                }
                else
                {
                    TempData["AlertMsg"] = userdetails != null ? "" : "NotFound";
                    return View(model);
                }
            }
            else
            {
                TempData["AlertMsg"] = "Error";
                return View(model);
            }

        }

        #endregion

        #region logout

        [AllowAnonymous]
        public IActionResult Logout()
        {
            var value = JsonConvert.DeserializeObject(_session.GetString("LoginCred"));
            _session.Clear();
            ViewBag.alertMsg = 202;
            return RedirectToAction("Login", "Home");
        }

        #endregion

        #region registration

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(UsersVM model)
        {
            if (ModelState.IsValid)
            {
                Users users = _mapper.Map<Users>(model);

                if (users.Id == 0)
                {

                    users.EmailActivationCode = Guid.NewGuid();
                    var save = await _usersInterface.Registration(users);

                    if (save > 0)
                    {
                        Users userdetails = await _usersInterface.GetUsersDetails(model.UniqueId, model.Email);
                        SendVerificationLinkEmail(userdetails.Email, userdetails.EmailActivationCode);
                        TempData["AlertMsg"] = "Saved";
                    }
                    else
                    {
                        TempData["AlertMsg"] = "User already exists";
                    }
                }
            }
            model = new UsersVM();
            ModelState.Clear();
            return View(model);
        }

        #endregion

        #region SendVerificationLinkEmail 
        public string SendVerificationLinkEmail(string Email, Guid? EmailActivationCode)
        {
            try
            {
                var varifyUrl = "http://localhost:34161/Home/Registration_ActivateAccount?EmailActivationCode=" + EmailActivationCode;
                var fromMail = new MailAddress("projtest66@gmail.com", "Computerised Assingment");
                var toMail = new MailAddress(Email);
                var frontEmailPassowrd = "testPass@123";
                string subject = "Your account is successfull created";
                string body = "<br/><br/>We are excited to tell you that your account is" +
                  " successfully created. Please click on the link below to verify your account" +
                  " <br/><br/><a href='" + varifyUrl + "'>" + varifyUrl + "</a> ";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromMail.Address, frontEmailPassowrd)

                };
                using (var message = new MailMessage(fromMail, toMail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(message);
                return "Mail Seccesfully Sent!!!";
            }
            catch (Exception ex)
            {
                return "Mail Sent Failure due to : " + ex.Message + "!!!";
            }
        }
        #endregion

        #region email activaton

        [HttpGet]
        public async Task<IActionResult> Registration_ActivateAccount(Guid? EmailActivationCode)
        {
            var data = await _usersInterface.Registration_ActivateAccount(EmailActivationCode);
            TempData["AlertMsg"] = data > 0 ? "MailActive" : "MailActivated";
            return View();
        }

        #endregion
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
