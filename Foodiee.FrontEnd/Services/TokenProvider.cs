using Foodiee.FrontEnd.Services.IServices;
using Foodiee.FrontEnd.Utility;
using Microsoft.Identity.Client;

namespace Foodiee.FrontEnd.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public TokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void ClearToken(string name)
        {
            string Tname = SD.TokenCookie + "_Guru@gmail.com";
            httpContextAccessor.HttpContext.Response.Cookies.Delete(Tname);
        }

        public string? GetToken()
        {
            string? token = null;
            string names = SD.TokenCookie + "_Guru@gmail.com";
            bool? hastoken = httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(names, out token);
            return hastoken is true ? token : null;
        }

        public void SetToken(string name, string token)
        {
            string Tname = SD.TokenCookie + "_Guru@gmail.com";
            httpContextAccessor.HttpContext.Response.Cookies.Append(Tname, token);
        }
    }
}
