using System.ComponentModel.DataAnnotations;

namespace SmartNetERP.Models.Master
{
    public class MarriageStatus
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
