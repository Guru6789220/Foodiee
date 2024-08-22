namespace Authentication_API.Models.DTO
{
    public class loginResponseDto
    {
        public AppUserDto User { get; set; }
        public string Token { get; set; }
    }
}
