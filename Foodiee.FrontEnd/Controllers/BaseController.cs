using Foodiee.FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Foodiee.FrontEnd.Controllers
{
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string Folderpath;

        
        protected async Task<string> UserName()
        {
            string username = User.FindFirstValue(ClaimTypes.Name);
            if (username == null)
            {
                
                TempData["error"] = "Please Login To Save Data";
            }
            return username;
        }

        protected async Task<string> SaveImages(IFormFile FileDetails)
        {
            string FilePath="";
            if(FileDetails!=null && FileDetails.Length>0)
            {
                string FileName=Path.GetFileName(FileDetails.FileName);
                FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + FileName;
                 FilePath=Path.Combine("E:\\MVC\\UploadedFiles", FileName);

                using(var stream=new FileStream(FilePath,FileMode.CreateNew))
                {
                    await FileDetails.CopyToAsync(stream);
                }

            }
            return FilePath;
        }

        public class Images
        {
            public string? FileName { get; set; }
            public string? FilePath { get; set; }
        }
    }
}
