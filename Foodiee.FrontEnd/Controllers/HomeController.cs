using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Foodiee.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategory_BrandService _category_BrandService;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger,ICategory_BrandService category_BrandService,IProductServices productServices)
        {
            _logger = logger;
            _category_BrandService = category_BrandService;
            _productServices = productServices;
        }
        public class Productdetails()
        {
            public int ProductId { get; set; }
            public string ProductDescription { get; set; }
            public string ProductName { get; set; }
            public decimal BasicPrice { get; set; }
            public string Images { get; set; }
        }
        public async Task<IActionResult> Index()
        {
           
            Response res = await _category_BrandService.ViewBrands();
            var BrandList = JsonConvert.DeserializeObject<List<BrandDTO>>(res.Result.ToString()).Select(s => new {s.BrandName,s.BrandLogo }).ToList();

            Response ress = await _productServices.LoadProducts();
            var products = JsonConvert.DeserializeObject<List<Productdetails>>(ress.Result.ToString());

            ViewBag.BrandLogo = BrandList;
            ViewBag.ProductDetails= products;
            return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //dto's

        public class ProductDetails()
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }

            public string ProductDescription { get; set; }
            public decimal BasicPrice { get; set; }

            public List<productFilepath> ProductImages { get; set; }

        }
        public class productFilepath()
        {
            public int ProductId { get; set; }
            public string Imagess { get; set; }
        }
    }
}
