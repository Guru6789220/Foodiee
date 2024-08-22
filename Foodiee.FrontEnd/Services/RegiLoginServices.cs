using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Foodiee.FrontEnd.Utility;

namespace Foodiee.FrontEnd.Services
{
    public class RegiLoginServices:IRegiLoginServices
    {
        private readonly IBaseService baseService;
        public RegiLoginServices(IBaseService baseService)
        {
            this.baseService = baseService;  
        }

        public async Task<Response> Login(LoginDTO loginDTO)
        {
            return await baseService.SendAsync(new Request()
            {
                ApiMethod=SD.Apitype.POST,
                Url=SD.AuthApiBase+ "/api/AuthAPI/login",
                Data=loginDTO,
            

            });
        }
    }
}
