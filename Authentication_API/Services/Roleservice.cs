using Authentication_API.DB;
using Authentication_API.Models;
using Authentication_API.Models.DTO;
using Authentication_API.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace Authentication_API.Services
{
    public class Roleservice:IRoleservice
    {
        public readonly RoleManager<RolesMaster> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DBConnect db;
        private ResponseDTO response;

        public Roleservice(RoleManager<RolesMaster> roleManager,UserManager<ApplicationUser> userManager,DBConnect db)
        {
            this.roleManager = roleManager;
            this.db = db;
            this.userManager = userManager;
            response = new ResponseDTO();
        }

        public async Task<ResponseDTO> RoleCreation(RolesDTO rolesDto)
        {
            if(rolesDto != null)
            {
                var role=db.RolesMasters.FirstOrDefault(r=>r.Name.ToLower()==rolesDto.Name.ToLower());
                if(role==null)
                {
                    RolesMaster roles = new RolesMaster()
                    {
                        Name = rolesDto.Name,
                        NormalizedName = rolesDto.NormalizedName,
                        createdDate = DateTime.Now,ConcurrencyStamp=null
                    };
                    roleManager.CreateAsync(roles).GetAwaiter().GetResult();
                    response.Success= true;
                    response.Message = "Role Created Sucessfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Role Already Exist";
                }
               
            }
            else
            {
                response.Success = false;
                response.Message = "No Data To Save";
            }
            return response;
        }

        public async Task<ResponseDTO> UserToRoleMapping(string User, string RoleName)
        {
            //var user = db.ApplicationUser.FirstOrDefault(r => r.UserName.ToLower() == User.ToLower());
            var user = db.ApplicationUser.FirstOrDefault(u => u.UserName.ToLower() == User.ToLower());
            if (user != null)
            {
                if((roleManager.RoleExistsAsync(RoleName).GetAwaiter().GetResult()))
                {
                    await userManager.AddToRoleAsync(user, RoleName);
                    response.Success = true;
                    response.Message = "User To Role Mapped Sucessfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Not A Valid Role";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Not A Valid User";
            }
            return response;

        }
    }
}
