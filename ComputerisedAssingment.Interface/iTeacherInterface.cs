using ComputerisedAssingment.ModelEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerisedAssingment.Interface
{
    public interface iTeacherInterface
    {
        Task<int> TeacherUpload(TeacherUpload teacherUpload);
        Task<List<TeacherUpload>> GetAllUploadView(string TeacherUniqueId);
        Task<List<TeacherUpload>> GetAllTeacherUploadDropdown(string StudentUniqueId);
        Task<List<StudentUpload>> StudentUploadData(string TeacherUniqueId);
        Task<AssingStudents> GetTeacherByStudentID(string StudentUniqueId);
    }
}
