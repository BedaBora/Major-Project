using AutoMapper;
using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ComputerisedAssingment.App.Controllers
{
    public class TeacherController : Controller
    {
        private iUsersInterface _usersInterface;
        private iTeacherInterface _teacherInterface;
        private iStudentInterface _studentInterface;
        private iAdminInterface _adminInterface;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public TeacherController(iUsersInterface usersInterface, iTeacherInterface teacherInterface, iStudentInterface studentInterface, iAdminInterface adminInterface, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _usersInterface = usersInterface;
            _teacherInterface = teacherInterface;
            _studentInterface = studentInterface;
            _adminInterface = adminInterface;
            _httpContextAccessor = httpContextAccessor;
        }

        #region students
        [HttpGet]
        public async Task<IActionResult> Students()
        {
            if (_session.GetString("LoginCred") != null)
            {
                var TeacherUniqueId = _session.GetString("LoginCredUniqueId");
                List<Users> studentsdata = await _adminInterface.GetAllStudents(TeacherUniqueId.Trim('"'));
                ViewBag.StudentsData = studentsdata;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }
        #endregion

        #region upload
        [HttpGet]
        public IActionResult Upload()
        {
            if (_session.GetString("LoginCred") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(TeacherUploadVM model)
        {
            if (_session.GetString("LoginCred") != null)
            {
                if (ModelState.IsValid)
                {

                    TeacherUpload teacherUpload = _mapper.Map<TeacherUpload>(model);
                    teacherUpload.Upload_file = model.Upload_file.FileName;

                    if (teacherUpload.Id == 0 && teacherUpload.Upload_file != null)
                    {
                        var save = await _teacherInterface.TeacherUpload(teacherUpload);
                        TempData["AlertMsg"] = save > 0 ? "Saved" : "Existed";
                    }

                    if (model.Upload_file == null || model.Upload_file.Length == 0)
                        return Content("file not selected");

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TeacherUpload", model.Upload_file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Upload_file.CopyToAsync(stream);
                    }


                }
                model = new TeacherUploadVM();
                ModelState.Clear();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

        }
        #endregion

        #region submitted
        [HttpGet]
        public async Task<IActionResult> Submitted()
        {
            if (_session.GetString("LoginCred") != null)
            {
                var TeacherUniqueId = _session.GetString("LoginCredUniqueId");
                List<StudentUpload> studentUploadData = await _teacherInterface.StudentUploadData(TeacherUniqueId.Trim('"'));
                ViewBag.StudentUploadData = studentUploadData;
                return View();
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
                var TeacherUniqueId = _session.GetString("LoginCredUniqueId");
                List<TeacherUpload> teacherUploaddata = await _teacherInterface.GetAllUploadView(TeacherUniqueId.Trim('"'));
                ViewBag.TeacherUploaddata = teacherUploaddata;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitGrade(string StudentUniqueId, int TeacherUploadId, decimal Grade)
        {
            var data = await _studentInterface.SubmitGrade(StudentUniqueId, TeacherUploadId, Grade);
            return Json(data);
        }
    }
}
