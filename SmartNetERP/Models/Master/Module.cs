using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class Module
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        [ValidateNever]
        public IEnumerable<Privilege> Privileges { get; set; }
    }
}
