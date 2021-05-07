using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelsEntity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerisedAssingment.Service
{
    public class AdminService : iAdminInterface
    {
        public async Task<int> AssingStudents(AssingStudents admin)
        {
            using (AppDBContext context = new AppDBContext())
            {
                var data = await context.AssingStudents.FirstOrDefaultAsync(x => x.TeacherUniqueId == admin.TeacherUniqueId && x.StudentUniqueId == admin.StudentUniqueId);

                if (data == null)
                {
                    await context.AssingStudents.AddAsync(admin);
                    await context.SaveChangesAsync();
                    return admin.Id;
                }
                return -1;
            }
        }

        public async Task<List<Users>> GetAllStudents(string TeacherUniqueId)
        {
            using (AppDBContext context = new AppDBContext())
            {
                return await (from a in context.Users
                              from b in context.AssingStudents.Where(x => x.TeacherUniqueId == TeacherUniqueId)
                              where a.UniqueId == b.StudentUniqueId
                              select new Users
                              {
                                  UniqueId = b.StudentUniqueId,
                                  FullName = a.FullName,
                              }).ToListAsync();
            }
        }

    }
}
