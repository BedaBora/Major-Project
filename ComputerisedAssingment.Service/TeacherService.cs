using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelsEntity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerisedAssingment.Service
{
    public class TeacherService : iTeacherInterface
    {
        public async Task<int> TeacherUpload(TeacherUpload teacherUpload)
        {
            using (AppDBContext context = new AppDBContext())
            {

                await context.TeacherUpload.AddAsync(teacherUpload);
                await context.SaveChangesAsync();
                return teacherUpload.Id;
            }
        }

        public async Task<List<TeacherUpload>> GetAllUploadView(string TeacherUniqueId)
        {
            using (AppDBContext context = new AppDBContext())
            {
                return await context.TeacherUpload.Where(x => x.TeacherUniqueId == TeacherUniqueId).ToListAsync();
            }
        }

        public async Task<List<TeacherUpload>> GetAllTeacherUploadDropdown(string StudentUniqueId)
        {
            using (AppDBContext context = new AppDBContext())
            {
                return await (from a in context.TeacherUpload
                              from b in context.AssingStudents.Where(x => x.StudentUniqueId == StudentUniqueId)
                              where a.TeacherUniqueId == b.TeacherUniqueId
                              select new TeacherUpload
                              {
                                  Id = a.Id,
                                  Title = a.Title,
                              }).ToListAsync();
            }
        }

        public async Task<List<StudentUpload>> StudentUploadData(string TeacherUniqueId)
        {
            using (AppDBContext context = new AppDBContext())
            {
                return await (from a in context.StudentUpload
                              from b in context.TeacherUpload.Where(x => x.TeacherUniqueId == TeacherUniqueId)
                              where a.TeacherUploadId == b.Id
                              select new StudentUpload
                              {
                                  Title = b.Title,
                                  StudentUniqueId = a.StudentUniqueId,
                                  Upload_file = a.Upload_file,
                                  Grade = a.Grade,
                                  Upload_date = a.Upload_date,
                                  TeacherUploadId = a.TeacherUploadId
                              }).ToListAsync();
            }
        }

        public async Task<AssingStudents> GetTeacherByStudentID(string StudentUniqueId)
        {
            using (AppDBContext context = new AppDBContext())
            {
                var data = await context.AssingStudents.FirstOrDefaultAsync(x => x.StudentUniqueId == StudentUniqueId);
                return data;
            }
        }
    }
}
