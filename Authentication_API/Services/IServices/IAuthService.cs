using Authentication_API.Models.DTO;

namespace Authentication_API.Services.IServices
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto registerDto);
        Task<loginResponseDto> Login(LoginDto loginDto);
    }
}
