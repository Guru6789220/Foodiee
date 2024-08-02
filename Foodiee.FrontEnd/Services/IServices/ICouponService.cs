using Foodiee.FrontEnd.Models;

namespace Foodiee.FrontEnd.Services.IServices
{
    public interface ICouponService
    {
        Task<Response?> getCoupons();
        Task<Response?> CreateCoupon(CouponDTO couponDTO);

        Task<Response?> Deletecoupon(string couponcode);

    }
}
