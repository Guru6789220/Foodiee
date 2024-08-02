using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodiee.FrontEnd.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> Index()
        {
            List<CouponDTO> coupon = new List<CouponDTO>();
            Response response = await _couponService.getCoupons();
            if (response != null)
            {
                coupon = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }
            return View(coupon);
        }

        public  IActionResult NewCoupon()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewCoupon(CouponDTO coupon)
        {
            if(ModelState.IsValid)
            {
                Response response = await _couponService.CreateCoupon(coupon);
                if (response.Success==true)
                {
                    TempData["success"] = "Coupon Created Successfully";
                    return RedirectToAction("Index");
                }
                else{
                    TempData["error"] = response.Message;
                }
                
            }
            return View(coupon);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string CouponCode)
        {
            Response response = await _couponService.Deletecoupon(CouponCode);
            if(response.Result!=null && response.Success)
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }
    }
}
