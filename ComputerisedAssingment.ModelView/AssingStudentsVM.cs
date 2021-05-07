using System.ComponentModel;

namespace ComputerisedAssingment.ModelView
{
    public class AssingStudentsVM
    {
        public int? Id { get; set; }

        [DisplayName("Teacher")]
        public string TeacherUniqueId { get; set; }

        [DisplayName("Student")]
        public string[] StudentUniqueId { get; set; }

    }
}
