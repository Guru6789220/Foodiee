using System.ComponentModel.DataAnnotations;

namespace Authentication_API.Models.DTO
{
    public class RolesDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName { get; set; }
    }
}
