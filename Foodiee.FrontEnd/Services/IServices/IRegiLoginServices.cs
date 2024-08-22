using Foodiee.FrontEnd.Models;

namespace Foodiee.FrontEnd.Services.IServices
{
    public interface IRegiLoginServices
    {
        Task<Response> Login(LoginDTO loginDTO);
    }
}
