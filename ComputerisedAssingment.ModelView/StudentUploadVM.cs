using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace ComputerisedAssingment.ModelView
{
    public class StudentUploadVM
    {
        public int? Id { get; set; }
        [DisplayName("Title")]
        public string TeacherUploadId { get; set; }
        [DisplayName("Upload")]
        public IFormFile Upload_file { get; set; }
        public string StudentUniqueId { get; set; }


    }
}
