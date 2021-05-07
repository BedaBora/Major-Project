using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelsEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerisedAssingment.Service
{
    public class StudentService : iStudentInterface
    {

        public async Task<int> StudentUpload(StudentUpload studentUpload)
        {
            using (AppDBContext context = new AppDBContext())
            {
                studentUpload.Upload_date = DateTime.Now;
                await context.StudentUpload.AddAsync(studentUpload);
                await context.SaveChangesAsync();
                return studentUpload.Id;
            }
        }

        public async Task<List<StudentUpload>> GetAllUploadView(string StudentUniqueId)
        {
            using (AppDBContext context = new AppDBContext())
            {
                return await context.StudentUpload.Where(x => x.StudentUniqueId == StudentUniqueId).ToListAsync();
            }
        }


        public async Task<int> SubmitGrade(string StudentUniqueId, int TeacherUploadId, decimal Grade)
        {
            using (AppDBContext context = new AppDBContext())
            {
                var data = await context.StudentUpload.AsNoTracking().FirstOrDefaultAsync(x => x.StudentUniqueId == StudentUniqueId && x.TeacherUploadId == TeacherUploadId);

                if (data != null)
                {
                    data.Grade = Grade;
                    context.StudentUpload.Update(data);
                    await context.SaveChangesAsync();
                    return data.Id;
                }
                return 0;
            }
        }
    }
}
