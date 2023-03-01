using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class BloodType
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string bloodType { get; set; }
        public bool IsActive { get; set; }
    }
}
