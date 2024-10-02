using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodiee.FrontEnd.Controllers
{
    public class SellersController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICategory_BrandService category_Brand;
       

        public SellersController(IHttpContextAccessor httpContextAccessor,ICategory_BrandService category_Brand)
        {
            _httpContextAccessor = httpContextAccessor;
            this.category_Brand = category_Brand;
            
        }
        public IActionResult Category()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Category(CategoryDTO categoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message.ToString();
            }
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<JsonResult> SaveFile(IFormFile CategoryImage)
        {
            string message = null;
            if (CategoryImage.Length > 0 && CategoryImage.Length < (1 * 1024 * 1024))
            {
                string? oldpath = _httpContextAccessor.HttpContext?.Session.GetString("FilePath");
                if (oldpath != null && oldpath != "")
                {
                    System.IO.File.Exists(oldpath);
                    System.IO.File.Delete(oldpath);
                }
                
                    var path = Path.Combine("E:\\MVC\\UploadedFiles\\", CategoryImage.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                       await CategoryImage.CopyToAsync(stream);
                       
                   
                    }
                message = "/uploadedfiles/" + CategoryImage.FileName;
            }
            
            else
            {
                message = "Error Occured During ImageSave";
            }

            return Json(message);
        }


        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandDTO brand)
        {
            brand.CreatedBy = await UserName();
            
            if(ModelState.IsValid)
            {
                Response res = await category_Brand.SaveDetails(brand);
                if(res.Success)
                {
                    TempData["success"] = res.Message;
                    return RedirectToAction("BrandDetails");
                }
                else
                {
                    TempData["error"] = res.Message;
                }
            }
            else
            {
                return View(brand);
            }
            return View();
        }
       

        [HttpGet]
        public async Task<IActionResult> BrandDetails()
        {
            List<BrandDTO> Brand = new();
            Response res = await category_Brand.ViewBrands();
            if (res.Success)
            {
                Brand = JsonConvert.DeserializeObject<List<BrandDTO>>(res.Result.ToString());
               
            }
            ViewBag.BrandDetails = Brand;
            return View();
        }
    }
}
