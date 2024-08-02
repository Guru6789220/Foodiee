using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Foodiee.FrontEnd.Utility;

namespace Foodiee.FrontEnd.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;   
        }

        public async Task<Response?> CreateCoupon(CouponDTO couponDTO)
        {
            try
            {
                return await _baseService.SendAsync(new Request()
                {
                    ApiMethod = SD.Apitype.POST,
                    Url = SD.CouponApiBase + "/api/Coupon",
                    Data= couponDTO
                    
                });
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }

        public async Task<Response?> Deletecoupon(string couponcode)
        {
            try
            {
                return await _baseService.SendAsync(new Request()
                {
                    ApiMethod = SD.Apitype.DELETE,
                    Url = SD.CouponApiBase + "/api/Coupon/" + couponcode.ToString()
                });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response?> getCoupons()
        {
            try
            {
                return await _baseService.SendAsync(new Request(){
                    ApiMethod=SD.Apitype.GET,
                    Url=SD.CouponApiBase+ "/api/Coupon"
                });

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
