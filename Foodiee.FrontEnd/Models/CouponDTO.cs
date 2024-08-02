using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Foodiee.FrontEnd.Models
{
    public class CouponDTO
    {
        [Required]
        [StringLength(10)]
        [MaxLength(10)]
        [DisplayName("Coupon Code")]
        public string? CouponCode { get; set; }

        [Required]
        [DisplayName("Minium Amount")]
        public decimal MiniumAmount { get; set; }

        [Required]
        [DisplayName("Discount Percentage")]
        public decimal DiscountPerce { get; set; }

        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public string CreatedBy { get; set; } = "";
    }
}
