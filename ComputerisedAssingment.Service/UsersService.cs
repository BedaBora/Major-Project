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
    public class UsersService : iUsersInterface
    {

        public async Task<Users> Login(string UniqueId, string Password)
        {
            using (AppDBContext context = new AppDBContext())
            {
                Users users = await context.Users.SingleOrDefaultAsync(x => x.UniqueId == UniqueId && x.Password == Password && x.Status == 1);

                return users;
            }
        }

        public async Task<Users> GetUsersDetails(string UniqueId, string Email)
        {
            using (AppDBContext context = new AppDBContext())
            {
                Users users = await context.Users.SingleOrDefaultAsync(x => x.UniqueId == UniqueId && x.Email == Email);

                return users;
            }
        }

        public async Task<int> Registration(Users users)
        {
            using (AppDBContext context = new AppDBContext())
            {
                var data = await context.Users.FirstOrDefaultAsync(x => x.UniqueId == users.UniqueId || x.Email == users.Email);

                if (data == null)
                {
                    await context.Users.AddAsync(users);
                    await context.SaveChangesAsync();
                    return users.Id;
                }
                return -1;
            }
        }

        public async Task<int> Registration_ActivateAccount(Guid? EmailActivationCode)
        {
            int result = 0;

            using (AppDBContext context = new AppDBContext())
            {
                var Usersdata = await context.Users.FirstOrDefaultAsync(x => x.EmailActivationCode == EmailActivationCode);

                if (Usersdata != null)
                {
                    //category
                    Usersdata.Status = 1;
                    Usersdata.EmailActivationCode = null;
                    context.Entry(Usersdata).State = EntityState.Modified;
                    context.Entry(Usersdata).Property("Status").IsModified = true;
                    context.Entry(Usersdata).Property("EmailActivationCode").IsModified = true;

                    await context.SaveChangesAsync();
                    return Usersdata.Status;
                }
                return result;
            }
        }

        public async Task<List<Users>> GetAllTeacherDropdown()
        {
            using (AppDBContext context = new AppDBContext())
            {
                return await context.Users.Where(x => x.UserType == 0 && x.Status == 1).ToListAsync();
            }
        }
    }
}
