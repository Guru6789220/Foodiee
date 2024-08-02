using Foodiee.FrontEnd.Models;

namespace Foodiee.FrontEnd.Services.IServices
{
    public interface IBaseService
    {
        Task<Response?> SendAsync(Request request);
    }
}
