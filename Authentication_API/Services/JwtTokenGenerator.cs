using Authentication_API.Models;
using Authentication_API.Models.DTO;
using Authentication_API.Services.IServices;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication_API.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration configuration;
        public JwtTokenGenerator(IConfiguration configuration)
        {
                this.configuration = configuration;
        }
        public async Task<string> GenerateToken(AppUserDto userdto)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]));
            var credentails = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,userdto.ApplicantName),
                new Claim(JwtRegisteredClaimNames.Email,userdto.Email),
                new Claim(JwtRegisteredClaimNames.NameId,userdto.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentails
                );

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
