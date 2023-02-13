using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class Privilege
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string Name { get; set; }
        [ValidateNever]
        public List<RolePrivilege> RolePrivileges { get; set; }
        public bool IsActive = true;
    }
}
