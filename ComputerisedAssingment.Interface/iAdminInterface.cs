using ComputerisedAssingment.ModelEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerisedAssingment.Interface
{
    public interface iAdminInterface
    {
        Task<int> AssingStudents(AssingStudents admin);
        Task<List<Users>> GetAllStudents(string TeacherUniqueId);

    }
}
