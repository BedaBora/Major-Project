using ComputerisedAssingment.ModelEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerisedAssingment.Interface
{
    public interface iUsersInterface
    {
        Task<Users> Login(string UniqueId, string Password);
        Task<Users> GetUsersDetails(string UniqueId, string Email);
        Task<int> Registration(Users users);
        Task<int> Registration_ActivateAccount(Guid? EmailActivationCode);
        Task<List<Users>> GetAllTeacherDropdown();

    }
}
