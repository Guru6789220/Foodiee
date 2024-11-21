using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodiee.FrontEnd.Models
{
    public class ProductsDTO
    {
        public List<Brands>? Brand { get; set; } // Should match "Brand" in JSON
        public List<Categorys>? Category { get; set; } // Should match "Category" in JSON

        [Required(ErrorMessage = "Select Category")]
        [DisplayName("Category Type")]
        [RegularExpression("^[\\d]$", ErrorMessage = "Select Category Type")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "Select Brand")]
        [DisplayName("Brand")]
        [RegularExpression("^\\d{0,4}$", ErrorMessage = "Select Brand ")]
        public int? BrandId { get; set; }

        [Required(ErrorMessage = "Enter Product Code"), MaxLength(15)]
        [DisplayName("Product Code")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Enter Product Name"), MaxLength(50)]
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Enter Base Price"), MaxLength(10)]
        [DisplayName("Base Price")]
        public string? BasePrice { get; set; }

        
        [Required(ErrorMessage = "Upload File,File Should Be in png,jpg,jpeg")]
        [DisplayName("Product Image")]
        public List<IFormFile> ProductImage { get; set; }

       

        [Required(ErrorMessage = "Enter Product Description"), MaxLength(1500)]
        [DisplayName("Product Description")]
        public string? ProductDesc { get; set; }

        [DisplayName("Product Highlight's Avaliable")]
        public int IsAvaliable { get; set; }

        public List<Images> FilePaths { get; set; } = new List<Images>();

       
        [MaxLength(2500)]
        public string? productHighlight1 { get; set; }

        public List<IFormFile>? HighlightImage1 { get; set; } = new List<IFormFile>();

        [MaxLength(2500)]
        public string? productHighlight2 { get; set; }

        public List<IFormFile>? HighlightImage2 { get; set; } = new List<IFormFile>();

        [MaxLength(2500)]
        public string? productHighlight3 { get; set; }

        public List<IFormFile>? HighlightImage3 { get; set; } = new List<IFormFile>();




    }
        public class Brands
        {
            public int? BrandId { get; set; }
            public string? BrandName { get; set; }
        }

        public class Categorys
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
    
    public class Images
    {
        public string? FilePath { get; set; }
    }
}


