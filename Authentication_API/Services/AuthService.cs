using Authentication_API.DB;
using Authentication_API.Models;
using Authentication_API.Models.DTO;
using Authentication_API.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly DBConnect db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<RolesMaster> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(DBConnect db,UserManager<ApplicationUser> userManager,RoleManager<RolesMaster> roleManager,IJwtTokenGenerator jwtTokenGenerator)
        {
            this.db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<loginResponseDto> Login(LoginDto loginDto)
        {
            var user=db.ApplicationUser.FirstOrDefault(u=>u.UserName.ToLower()==loginDto.UserName.ToLower());
            bool isvalid=await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(user==null ||isvalid==false)
            {
                return new loginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }
             
            AppUserDto userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                ApplicantName = user.ApplicantName
            };
            //to generate token we need to send AppUserDto
           var newtoken= await _jwtTokenGenerator.GenerateToken(userDto);

            loginResponseDto loginResponseDto = new() { User = userDto, Token = newtoken };
            return loginResponseDto;
        }

        public async Task<string> Register(RegisterDto registerDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = registerDto.Email,
                NormalizedEmail = registerDto.Email,
                ApplicantName = registerDto.ApplicantName,
                UserName = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber

            };
            try
            {
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if(result.Succeeded)
                {
                    var usertoreturn = db.ApplicationUser.First(u => u.UserName == registerDto.Email);
                    AppUserDto userdto = new()
                    {
                        Email = usertoreturn.Email,
                        Id = usertoreturn.Id,
                        ApplicantName = usertoreturn.ApplicantName,
                        PhoneNumber = usertoreturn.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch(Exception ex)
            {

            }

            return "Error occured";
        }
    }
}
