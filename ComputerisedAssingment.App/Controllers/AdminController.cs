using AutoMapper;
using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace ComputerisedAssingment.App.Controllers
{
    public class AdminController : Controller
    {
        private iUsersInterface _usersInterface;
        private iAdminInterface _adminInterface;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public AdminController(iUsersInterface usersInterface, iAdminInterface adminInterface, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _usersInterface = usersInterface;
            _adminInterface = adminInterface;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IActionResult AssingStudents()
        {
            if (_session.GetString("LoginCred") != null)
            {
                ViewBag.TeacherData = GetAllTeacherDropdown();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssingStudents(AssingStudentsVM model)
        {
            if (_session.GetString("LoginCred") != null)
            {
                if (ModelState.IsValid)
                {
                    dynamic data = new ExpandoObject();

                    for (var i = 0; i < model.StudentUniqueId.Length; i++)
                    {
                        data.Id = model.Id;
                        data.TeacherUniqueId = model.TeacherUniqueId;
                        data.StudentUniqueId = model.StudentUniqueId[i];

                        AssingStudents admin = _mapper.Map<AssingStudents>(data);

                        if (admin.Id == 0)
                        {
                            var save = await _adminInterface.AssingStudents(admin);
                            TempData["AlertMsg"] = save > 0 ? "Saved" : "Existed";
                        }
                    }
                }
                model = new AssingStudentsVM();
                ModelState.Clear();
                ViewBag.TeacherData = GetAllTeacherDropdown();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }

        private async Task<List<SelectListItem>> GetAllTeacherDropdown()
        {

            List<SelectListItem> data = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select Teacher"}
            };

            foreach (Users a in await _usersInterface.GetAllTeacherDropdown())//only active data will show
            {
                var item = new SelectListItem() { Value = a.UniqueId.ToString(), Text = a.FullName };
                data.Add(item);
            }

            return data;
        }
    }
}
