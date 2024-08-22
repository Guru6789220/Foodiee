using Authentication_API.Models.DTO;
using Authentication_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_API.Controllers
{
    [Route("api/AuthAPI")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        public readonly IAuthService authService;
        private readonly IRoleservice rolesManager;
        private ResponseDTO responseDTO;
        public AuthAPIController(IAuthService authService,IRoleservice rolesManager)
        {
            this.authService = authService;
            this.rolesManager = rolesManager;
            responseDTO = new();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var res=await authService.Register(registerDto);
                if (res != null)
                {
                    responseDTO.Message = res;
                }
                else
                {
                    responseDTO.Success = true;
                    
                }
                return Ok(responseDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginRequest)
        {
            if (loginRequest == null)
            {
                responseDTO.Message = "Invalid Login data";
                return BadRequest(responseDTO);
            }
            else
            {
                var loginresponse = await authService.Login(loginRequest);
                if (loginresponse.User == null)
                {
                    responseDTO.Success = false;
                    responseDTO.Message = "Username Or Password is incorrect";
                    return BadRequest(responseDTO);
                }

                
                responseDTO.Result = loginresponse;
                responseDTO.Success = true;
                return Ok(responseDTO);
            }
            
        }
        [HttpPost]
        [Route("UserToRole/{username}/{rolename}")]
        public async Task<IActionResult> UserToRole(string username,string rolename)
        {
            try
            {
                if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(rolename))
                {
                    responseDTO=await rolesManager.UserToRoleMapping(username, rolename);
                }
                else
                {
                    responseDTO.Message = "Not A valid UserName Or Role Name";
                }
                return Ok(responseDTO);
            }
            catch(Exception ex)
            {
                responseDTO.Message = ex.Message;
                responseDTO.Success = false;
                return BadRequest(responseDTO);
            }
        }

        [HttpPost("RoleCreate")]

        public async Task<IActionResult> RoleCreation([FromBody] RolesDTO rolesDto)
        {
            try
            {
                if(rolesDto!=null)
                {
                    responseDTO = await rolesManager.RoleCreation(rolesDto);

                }
                else
                {
                    responseDTO.Success = false;
                    responseDTO.Message = "No data to save";
                }
                return Ok(responseDTO);
            }
            catch(Exception ex)
            {
                responseDTO.Message = ex.Message;
                responseDTO.Success = false;
                return BadRequest(responseDTO);
            }
        }
    }
}
