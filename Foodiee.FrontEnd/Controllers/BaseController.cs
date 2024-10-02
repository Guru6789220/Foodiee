using Foodiee.FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Foodiee.FrontEnd.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<string> UserName()
        {
            string username = User.FindFirstValue(ClaimTypes.Name);
            if (username == null)
            {
                
                TempData["error"] = "Please Login To Save Data";
            }
            return username;
        }
    }
}
