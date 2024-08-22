using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Authentication_API.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required,MaxLength(50)]
        public string ApplicantName { get; set; }

        [Required, MaxLength(1000)]
        public string Address { get; set; } = "address";
    }
}
