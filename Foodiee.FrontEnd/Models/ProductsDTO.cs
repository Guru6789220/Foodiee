using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foodiee.FrontEnd.Models
{
    public class ProductsDTO
    {
        public List<Brands> Brand { get; set; } // Should match "Brand" in JSON
        public List<Categorys> Category { get; set; } // Should match "Category" in JSON

        [Required]
        [DisplayName("Category Type")]
        [RegularExpression("^[\\d]$", ErrorMessage = "Select Category Type")]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Brand")]
        [RegularExpression("^[\\d]$", ErrorMessage = "Select Brand")]
        public int BrandId { get; set; }

        [Required, MaxLength(15)]
        [DisplayName("Product Code")]
        public string? ProductCode { get; set; }

        [Required, MaxLength(50)]
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Enter Base Price"), MaxLength(10)]
        [DisplayName("Base Price")]
        public decimal? BasePrice { get; set; }

        [Required(ErrorMessage = "Upload File,File Should Be in png,jpg,jpeg")]
        [DisplayName("Product Image")]
        public string? ProductImage { get; set; }

        [Required(ErrorMessage = "Enter Product Description"), MaxLength(200)]
        [DisplayName("Product Description")]
        public string? ProductDesc { get; set; }

        [DisplayName("Highlight's Avaliable")]
        public int IsAvaliable { get; set; }



    }
        public class Brands
        {
            public int BrandId { get; set; }
            public string BrandName { get; set; }
        }

        public class Categorys
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
    
    
}


