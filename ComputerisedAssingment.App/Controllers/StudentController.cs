using AutoMapper;
using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ComputerisedAssingment.App.Controllers
{
    public class StudentController : Controller
    {
        private iTeacherInterface _teacherInterface;
        private iStudentInterface _studentInterface;
        private iAdminInterface _adminInterface;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public StudentController(iTeacherInterface teacherInterface, iStudentInterface studentInterface, iAdminInterface adminInterface, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _teacherInterface = teacherInterface;
            _studentInterface = studentInterface;
            _adminInterface = adminInterface;
            _httpContextAccessor = httpContextAccessor;
        }


        #region upload
        [HttpGet]
        public async Task<IActionResult> Upload()
        {
            if (_session.GetString("LoginCred") != null)
            {
                var StudentUniqueId = _session.GetString("LoginCredUniqueId");
                AssingStudents teacherData = await _teacherInterface.GetTeacherByStudentID(StudentUniqueId.Trim('"'));
                ViewBag.TeacherData = teacherData;
                if (teacherData == null)
                {
                    string msg = "NotAssinged";
                    return RedirectToAction("Login", "Home", new { msg = msg });

                }
                else
                {
                    ViewBag.TitleData = GetAllTeacherUploadDropdown();
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(StudentUploadVM model)
        {
            if (_session.GetString("LoginCred") != null)
            {
                if (ModelState.IsValid)
                {

                    StudentUpload studentUpload = _mapper.Map<StudentUpload>(model);
                    studentUpload.Upload_file = model.Upload_file.FileName;

                    if (studentUpload.Id == 0 && studentUpload.Upload_file != null)
                    {
                        var save = await _studentInterface.StudentUpload(studentUpload);
                        TempData["AlertMsg"] = save > 0 ? "Saved" : "Existed";
                    }

                    if (model.Upload_file == null || model.Upload_file.Length == 0)
                        return Content("file not selected");

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/StudentUpload", model.Upload_file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Upload_file.CopyToAsync(stream);
                    }


                }
                model = new StudentUploadVM();
                ModelState.Clear();
                var StudentUniqueId = _session.GetString("LoginCredUniqueId");
                AssingStudents teacherData = await _teacherInterface.GetTeacherByStudentID(StudentUniqueId.Trim('"'));
                ViewBag.TeacherData = teacherData;
                ViewBag.TitleData = GetAllTeacherUploadDropdown();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

        }
        #endregion



        #region view

        [HttpGet]
        public async Task<IActionResult> view()
        {
            if (_session.GetString("LoginCred") != null)
            {

                var StudentUniqueId = _session.GetString("LoginCredUniqueId");
                AssingStudents teacherData = await _teacherInterface.GetTeacherByStudentID(StudentUniqueId.Trim('"'));
                List<TeacherUpload> teacherUploaddata = await _teacherInterface.GetAllUploadView(teacherData.TeacherUniqueId);
                ViewBag.TeacherUploaddata = teacherUploaddata;
                List<StudentUpload> studentUploaddata = await _studentInterface.GetAllUploadView(StudentUniqueId.Trim('"'));
                ViewBag.StudentUploaddata = studentUploaddata;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }
        #endregion

        private async Task<List<SelectListItem>> GetAllTeacherUploadDropdown()
        {
            var StudentUniqueId = _session.GetString("LoginCredUniqueId");

            List<SelectListItem> data = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select Title"}
            };

            foreach (TeacherUpload a in await _teacherInterface.GetAllTeacherUploadDropdown(StudentUniqueId.Trim('"')))//only active data will show
            {
                var item = new SelectListItem() { Value = a.Id.ToString(), Text = a.Title };
                data.Add(item);
            }

            return data;
        }
    }
}
