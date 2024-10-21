using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Foodiee.FrontEnd.Controllers
{
    public class SellersController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICategory_BrandService category_Brand;
        private readonly IProductServices productServices;

        public SellersController(IHttpContextAccessor httpContextAccessor,ICategory_BrandService category_Brand,IProductServices productServices)
        {
            _httpContextAccessor = httpContextAccessor;
            this.category_Brand = category_Brand;
            this.productServices= productServices;
            
        }
        public IActionResult Category()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Category(CategoryDTO categoryDTO)
        {
            try
            {
                categoryDTO.CreatedBy = await UserName();
                if (ModelState.IsValid)
                {
                    Response res=await category_Brand.SaveCategory(categoryDTO);
                    if(res.Success)
                    {
                        TempData["success"] = res.Message;
                        return RedirectToAction("CategoryDetails", "Sellers");
                    }
                    else
                    {

                    }
                }
                else
                {
                    return View(categoryDTO);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message.ToString();
            }
            return View(categoryDTO);
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

        [HttpGet]
        public async Task<IActionResult> CategoryDetails()
        {
            Response res = await category_Brand.CategoryDetails();
            if(res.Success&&res.Result!=null)
            {
                ViewBag.Categorys = JsonConvert.DeserializeObject<List<CategoryDTO>>(res.Result.ToString());
            }
            else
            {
                TempData["error"] = "No Data Found!";
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            Response ress = await productServices.Load_Category_Brand();
            if(ress.Success && ress.Result!=null) 
            {
                var res=JsonConvert.DeserializeObject<ProductsDTO>(ress.Result.ToString());
                ViewBag.Brand = new SelectList(res.Brand, "BrandId", "BrandName");
                ViewBag.Category = new SelectList(res.Category, "CategoryId", "CategoryName");
            }
            return View();
        }

    }

}
