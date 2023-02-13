using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Email { get; set; }
        [ValidateNever]
        public List<UserRole> UserRoles { get; set; }
        public bool IsActive = true;
    }
}
