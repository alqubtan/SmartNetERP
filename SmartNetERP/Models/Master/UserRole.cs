using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public Guid UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public Guid RoleId { get; set; }
        [ValidateNever]
        public Role Role { get; set; }

    }
}
