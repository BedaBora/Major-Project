using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerisedAssingment.ModelEntity
{
    public class StudentUpload
    {
        [Key]
        public int Id { get; set; }
        public int TeacherUploadId { get; set; }
        public string? Title { get; set; }
        public string Upload_file { get; set; }
        public string StudentUniqueId { get; set; }
        public string TeacherUniqueId { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Grade { get; set; }
        public DateTime Upload_date { get; set; }
        public DateTime Deadline { get; set; }
    }
}
