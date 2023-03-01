using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartNetERP.Models.Master
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }


    }



}

