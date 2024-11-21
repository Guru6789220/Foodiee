using Foodiee.FrontEnd.Models;

namespace Foodiee.FrontEnd.Services.IServices
{
    public interface IProductServices
    {
        public Task<Response> Load_Category_Brand();

        public Task<Response> SaveProduct(Products productsDTO);

        public Task<Response> LoadProducts();
    }
}
