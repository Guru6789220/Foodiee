using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Foodiee.FrontEnd.Models
{
    public class BrandDTO
    {
        public int BrandId { get; set; }
        [Required(ErrorMessage ="Enter Brand Name"),MaxLength(30)]
        [DisplayName("Brand Name")]
        public string? BrandName { get; set; }

        [Required(ErrorMessage ="Enter Brand Description"), MaxLength(500)]
        [DisplayName("Brand Description")]
        public string? BrandDesc { get; set; }
      
        [DisplayName("Brand Logo")]
        [Required(ErrorMessage ="Upload Image (jpg, png, jpeg, gif)")]
        public string? BrandLogo { get; set; }
        public string? CreatedBy { get; set; }

    }
}
