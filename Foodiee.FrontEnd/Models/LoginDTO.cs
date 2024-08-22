using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foodiee.FrontEnd.Models
{
    public class LoginDTO
    {
        [Required,MaxLength(50)]
        [DisplayName("UserName/Email ID")]
        public string userName { get; set; }

        [Required,MaxLength(18)]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required,MaxLength(8)]
        [DisplayName("Captcha")]
        public string Captcha { get; set; }

    }
}
