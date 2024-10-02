using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Foodiee.FrontEnd.Utility;

namespace Foodiee.FrontEnd.Services
{
    public class Category_BrandService : ICategory_BrandService
    {
        private readonly Response response;
        private readonly IBaseService baseService;
        public Category_BrandService(IBaseService baseService)
        {
           response= new Response();
            this.baseService = baseService;
        }

        public async Task<Response> SaveDetails(BrandDTO brand)
        {
            try
            {
                return await baseService.SendAsync(new Request
                {
                    ApiMethod = SD.Apitype.POST,
                    Url = SD.CouponApiBase + "/api/Category/SaveBrand",
                    Data = brand
                });
            }
            catch (Exception ex)
            {
                response.Result = "";
                response.Success = true;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<Response?> ViewBrands()
        {
            try
            {
                return await baseService.SendAsync(new Request
                {
                    ApiMethod=SD.Apitype.GET,
                    Url=SD.CouponApiBase+ "/api/Category/ViewBrand"
                });
            }
            catch(Exception ex)
            {
                response.Result = "";
                response.Success = true;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
