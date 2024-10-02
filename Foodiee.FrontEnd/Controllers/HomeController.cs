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

        public HomeController(ILogger<HomeController> logger,ICategory_BrandService category_BrandService)
        {
            _logger = logger;
            _category_BrandService = category_BrandService;
        }

        public async Task<IActionResult> Index()
        {
           
            Response res = await _category_BrandService.ViewBrands();
            var BrandList = JsonConvert.DeserializeObject<List<BrandDTO>>(res.Result.ToString()).Select(s => new {s.BrandName,s.BrandLogo }).ToList();
            ViewBag.BrandLogo = BrandList;
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
    }
}
