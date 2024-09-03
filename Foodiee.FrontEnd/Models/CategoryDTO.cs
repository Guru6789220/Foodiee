using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foodiee.FrontEnd.Models
{
    public class CategoryDTO
    {
        [Required]
        public CategoryTable CategoryDetails { get; set; }

        [Required]
        public string? CreatedBy { get; set; }
    }

    public class CategoryTable
    {
        [Required(ErrorMessage ="Enter Category Name"),MaxLength(100)]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage ="Enter Category Descryption"), MaxLength(500)]
        [DisplayName("Category Descryption")]
        public string? CategoryDesc { get; set; }

        [Required(ErrorMessage ="Upload Image -- .PNG , .JPG , .JPEG , .GIF  And Size Should Be Less Than 10MB")]
        [DisplayName("Category Image ")]
        public IFormFile? CategoryImageURL { get; set; }


    }
}
