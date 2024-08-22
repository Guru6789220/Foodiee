using Authentication_API.Models;
using Authentication_API.Models.DTO;

namespace Authentication_API.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(AppUserDto userdto);
    }
}
