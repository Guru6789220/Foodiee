using Authentication_API.Models.DTO;

namespace Authentication_API.Services.IServices
{
    public interface IRoleservice
    {
        Task<ResponseDTO> RoleCreation(RolesDTO rolesDto);
        Task<ResponseDTO> UserToRoleMapping(string User, string RoleName);
    }
}
