using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerisedAssingment.ModelEntity
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Email { get; set; }
        public Guid? EmailActivationCode { get; set; }
        public string FullName { get; set; }
        public int UserType { get; set; } = 0;
        public string Password { get; set; }
        public int Status { get; set; } = 0;

    }
}
