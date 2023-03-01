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
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public Guid ModuleId { get; set; }
        [ValidateNever]
        public Module Module { get; set; }
        public bool IsActive { get; set; }
    }
}
