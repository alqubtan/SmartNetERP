using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class Religion
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string religion { get; set; }
        public bool IsActive { get; set; }
    }
}
