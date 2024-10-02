using Foodiee.FrontEnd.Models;

namespace Foodiee.FrontEnd.Services.IServices
{
    public interface ICategory_BrandService
    {
        public Task<Response?> ViewBrands();
        public Task<Response> SaveDetails(BrandDTO brand);
       
    }
}
