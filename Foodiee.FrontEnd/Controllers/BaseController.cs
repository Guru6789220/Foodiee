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

        protected async Task<List<string>> SaveImages(List<IFormFile> FileDetails)
        {
            List<string>Afilepath = new List<string>();
            for (int i = 0; i < FileDetails.Count(); i++)
            {
                string FilePaths = "";
                if (FileDetails[i] != null && FileDetails[i].Length > 0)
                {
                    string FileName = Path.GetFileName(FileDetails[i].FileName);
                    FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + FileName;
                    FilePaths = Path.Combine("E:\\MVC\\UploadedFiles", FileName);
                    Afilepath.Add(FilePaths);
                    using (var stream = new FileStream(FilePaths, FileMode.CreateNew))
                    {
                        await FileDetails[i].CopyToAsync(stream);
                    }
                    
                }
            }
            return Afilepath;
        }

    }
}
