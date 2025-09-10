using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VISApp.Models
{
    public class Voter
    {
        [Key]
        public int VoterId { get; set; }
        [Required]
        [StringLength(75, ErrorMessage = "Name length should be less than 76")]
        [Display(Name = "Voter Name")]
        public string VoterName { get; set; }
        [Required]
        [Range(18, 60)]
        public int age { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime Dob { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Gender length should be less than 7")]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        [Phone(ErrorMessage = "please enter a valid phone no.")]
        [RegularExpression(@"^\d{10}$")]
        public string MobileNumber { get; set; }
    }
}
