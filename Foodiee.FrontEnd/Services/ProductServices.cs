using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Foodiee.FrontEnd.Utility;

namespace Foodiee.FrontEnd.Services
{
    public class ProductServices : IProductServices
    {
        private Response response;
        private readonly IBaseService baseService;
        public ProductServices(IBaseService baseService)
        {
            this.baseService = baseService;
            response = new Response();
        }
        public async Task<Response> Load_Category_Brand()
        {
            try
            {
                return await baseService.SendAsync(new Request
                {
                    ApiMethod = SD.Apitype.GET,
                    Url = SD.CouponApiBase + "/api/Category/NewProduct"
                });
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = null;
                response.Message= ex.Message;
                return response;
            }
        }

        public async Task<Response> SaveProduct(Products productsDTO)
        {
            try
            {
                return await baseService.SendAsync(new Request
                {
                    ApiMethod = SD.Apitype.POST,
                    Data = productsDTO,
                    Url = SD.CouponApiBase + "/api/Category/SaveProduct"
                });

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Result = null;

                return response;
            }
        }
    }
}
