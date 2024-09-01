using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Foodiee.FrontEnd.Controllers
{
    public class RegiLoginController : Controller
    {
        private readonly IRegiLoginServices regiLoginServices;
        private readonly ITokenProvider tokenProvider;
        public RegiLoginController(IRegiLoginServices regiLoginServices,ITokenProvider tokenProvider)
        {
            this.regiLoginServices = regiLoginServices;
            this.tokenProvider = tokenProvider;
        }
        public IActionResult Login()
        {
            string NewCode = GenerateCaptcha();
            ViewBag.captchacode = NewCode;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            if (loginDTO != null)
            {
               Response res=await regiLoginServices.Login(loginDTO);
                if(res.Success=true)
                {


                    LoginResponseDto loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(res.Result));

           
                    await SignInAsync(loginResponse);

                    tokenProvider.SetToken(loginResponse.User.Email,loginResponse.Token);
                    TempData["success"] = res.Message==""?"Login Sucessfull":res.Message;
                    return RedirectToAction("Index","Home");//("Action","Controller")
                }
                else
                {
                    TempData["error"] = res.Message;
                   
                }
            }
            return View(loginDTO);

        }

        [HttpGet]
        public ActionResult LogOut()
        {
            tokenProvider.ClearToken(User.Identity.Name);
            // Sign out the user if you're using cookie authentication
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public string GenerateCaptcha()
        {
            string letters= "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            char[] captchacode =new char[8];

            for(int i=0;i<captchacode.Length;i++)
            {
                int index=random.Next(letters.Length);
                captchacode[i]= letters[index];
            }
            return new string(captchacode);
        }
        [HttpGet]
        public JsonResult RegenerateCaptcha()
        {
            // Generate CAPTCHA code
            string captchaCode = GenerateCaptcha();

            // Return the CAPTCHA code as JSON
            return Json(captchaCode);
        }

        private async Task SignInAsync(LoginResponseDto loginResponseDto)
        {
            var handler = new JwtSecurityTokenHandler();
            var Jwt=handler.ReadJwtToken(loginResponseDto.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, 
                Jwt.Claims.FirstOrDefault(u=>u.Type==JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, 
                Jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.NameId, 
                Jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.NameId).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name, 
                Jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));
            
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

    }
}
