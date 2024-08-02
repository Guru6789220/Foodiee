using Foodiee.FrontEnd.Models;
using Foodiee.FrontEnd.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Foodiee.FrontEnd.Utility.SD;

namespace Foodiee.FrontEnd.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }
        public async Task<Response?> SendAsync(Request request)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("CouponApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "Application/json");
                message.RequestUri = new Uri(request.Url);
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data),Encoding.UTF8,"Application/Json");
                }
                HttpResponseMessage apiresponse = null;
                switch (request.ApiMethod)
                {
                    case Apitype.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case Apitype.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Apitype.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Apitype.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                }
              
                apiresponse = await client.SendAsync(message);

                switch(apiresponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { Success = false, Message = "Not Found" };
                    case HttpStatusCode.Unauthorized:
                        return new() { Success = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { Success = false,Message="Internal Server Erroe" };
                    default:
                        if (HttpStatusCode.OK == apiresponse.StatusCode)
                        {
                            var apicontent = await apiresponse.Content.ReadAsStringAsync();
                            var newresponse = JsonConvert.DeserializeObject<Response>(apicontent);
                            return newresponse;
                        }
                        else
                        {
                            return new() { Success = false, Message = "Error Occured" };
                        }     

                }
            }
            catch(Exception ex)
            {
                var dto = new Response()
                {
                    Success = false,
                    Message = ex.Message,
                    Result = ""
                };
            return dto;
            }
        }
    }
}
