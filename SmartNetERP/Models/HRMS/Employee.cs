using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartNetERP.Models.Master
{
    public class Employee:User
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string FatherName { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string GrandfatherName { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string FamilyName { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string MotherFullName { get; set; }

        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public Guid RelegionId { get; set; }
        [ValidateNever]
        [ForeignKey("RelegionId")]
        public Religion Relegion { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public Guid NationalityId { get; set; }
        [ValidateNever]
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }


        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public Guid BloodTypeId { get; set; }
        [ValidateNever]
        [ForeignKey("BloodTypeId")]
        public BloodType BloodType { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string BlaceOfBirth { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string DataOfBirth { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public Guid MarriageStatusId { get; set; }
        [ValidateNever]
        [ForeignKey("MarriageStatusId")]
        public MarriageStatus MarriageStatus { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? Notes { get; set; }

    }
}
