using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerisedAssingment.ModelEntity
{
    public class TeacherUpload
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Upload_file { get; set; }
        public string TeacherUniqueId { get; set; }
        public DateTime Deadline { get; set; }

    }
}
