using System.ComponentModel.DataAnnotations;

namespace Foodiee.FrontEnd.Models
{
    public class BaseDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string? CreatedBy { get; set; }
    }
}
