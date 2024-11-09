using System.ComponentModel.DataAnnotations;

namespace Foodiee.FrontEnd.Models
{
    public class Products
    {
        public int ProductId { get; set; }

        [Required]
        //foregin Key
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required, MaxLength(50)]
        public string ProductName { get; set; }

        [Required, MaxLength(1500)]
        public string ProductDescription { get; set; }

        [Required]
        public decimal BasicPrice { get; set; }

        //0 - not avaliable 1- avaliable
        public int ProductHighlight { get; set; } = 0;

        public int CreatedBy { get; set; }

        public List<Files> Images { get; set; }=new List<Files>();

       
    }
    public class Files
    {
        public string? FilePath { get; set; }

    }
}
