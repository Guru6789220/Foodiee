using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Authentication_API.Models.DTO
{
    public class RolesMaster:IdentityRole
    {
        [Required]
        public DateTime createdDate { get; set; }
    }
}
