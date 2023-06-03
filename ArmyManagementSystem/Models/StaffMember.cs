using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ArmyManagementSystem.Models
{
    public class StaffMember
    {
        [Key]
        public Guid StaffMemberId { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("serial number")]
        public string SerialNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("military rank")]
        public string Rank { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("surname")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("patronym")]
        public string FatherName { get; set; }

        [Required]
        [DisplayName("date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("hair color")]
        public string ColorOfHair { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("eye color")]
        public string ColorOfEyes { get; set; }

        [Required]
        [DisplayName("height")]
        public int Height { get; set; }

        [Required]
        [MaxLength(10)]
        [DisplayName("blood type")]
        public string BloodType { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [DisplayName("e-mail")]
        public string Email { get; set; }
    }
}
