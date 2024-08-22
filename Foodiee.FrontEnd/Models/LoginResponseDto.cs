using System.Text.Json.Serialization;

namespace Foodiee.FrontEnd.Models
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }

        public string Token { get; set; }
    }
}
