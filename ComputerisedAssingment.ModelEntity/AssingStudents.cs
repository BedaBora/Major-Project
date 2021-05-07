using System.ComponentModel.DataAnnotations;

namespace ComputerisedAssingment.ModelEntity
{
    public class AssingStudents
    {
        [Key]
        public int Id { get; set; }
        public string TeacherUniqueId { get; set; }
        public string StudentUniqueId { get; set; }
        public string? FullName { get; set; }
        public Users Users { get; set; }


    }
}
