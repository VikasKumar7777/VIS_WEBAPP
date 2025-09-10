using System.ComponentModel.DataAnnotations;

namespace VISApp.Models
{
    public class AdminUser
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
