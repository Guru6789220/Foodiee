using Foodiee.FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foodiee.FrontEnd.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Category(CategoryDTO categoryDTO)
        {
            try
            {
                if(!ModelState.IsValid)
                {

                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message.ToString();
            }
           return View(categoryDTO);
        }
    }
}
