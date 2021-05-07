using ComputerisedAssingment.ModelEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerisedAssingment.Interface
{
    public interface iStudentInterface
    {
        Task<int> StudentUpload(StudentUpload studentUpload);
        Task<List<StudentUpload>> GetAllUploadView(string StudentUniqueId);
        Task<int> SubmitGrade(string StudentUniqueId, int TeacherUploadId, decimal Grade);

    }
}
