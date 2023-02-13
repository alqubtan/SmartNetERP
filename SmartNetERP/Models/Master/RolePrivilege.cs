using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class RolePrivilege
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public Guid RoleId { get; set; }
        [ValidateNever]
        public Role Role { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public Guid PrivilegeId { get; set; }
        [ValidateNever]
        public Privilege Privilege { get; set; }

    }
}
