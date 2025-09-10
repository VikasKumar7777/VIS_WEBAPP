using System.ComponentModel.DataAnnotations;

namespace VISApp.Models
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        [Display(Name ="City Name")]
        public string Name { get; set; }
    }
}
