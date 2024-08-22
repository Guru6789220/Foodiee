using System.Text.Json.Serialization;

namespace Authentication_API.Models.DTO
{
    public class AppUserDto
    {
       
        public string Id { get; set; }
        
        public string ApplicantName { get; set; }
        
        public string Email { get; set; }
      
        public string PhoneNumber { get; set; }
    }
}
