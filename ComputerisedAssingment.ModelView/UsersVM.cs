using System.ComponentModel;

namespace ComputerisedAssingment.ModelView
{
    public class UsersVM
    {
        public int? Id { get; set; }

        [DisplayName("Id")]
        public string UniqueId { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Are you a student?")]
        public int UserType { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }


    }
}
