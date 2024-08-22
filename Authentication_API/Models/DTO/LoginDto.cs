using System.ComponentModel.DataAnnotations;

namespace Authentication_API.Models.DTO
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
