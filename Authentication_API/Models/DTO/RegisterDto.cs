using System.ComponentModel.DataAnnotations;

namespace Authentication_API.Models.DTO
{
    public class RegisterDto
    {
        [Required]
        public string ApplicantName { get; set; }
        [Required]
        public string Email { get; set;}
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
