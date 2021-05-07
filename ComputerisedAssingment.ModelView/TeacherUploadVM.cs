using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;

namespace ComputerisedAssingment.ModelView
{
    public class TeacherUploadVM
    {
        public int? Id { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Upload")]
        public IFormFile Upload_file { get; set; }
        [DisplayName("Deadline")]
        public DateTime Deadline { get; set; }
        public string TeacherUniqueId { get; set; }


    }
}
