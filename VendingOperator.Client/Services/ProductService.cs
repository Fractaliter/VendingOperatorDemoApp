using VendingOperator.Client.Shared;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;
using System.Web.Http;

namespace VendingOperator.Client.Services
{
    public class ProductService : IProductService
    {
        private IHttpService _httpService;

        public ProductService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResult<Product>> GetProducts(string? name, string page)
        {
            return await _httpService.Get<PagedResult<Product>>("api/product" + "?page=" + page + "&name=" + name);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpService.Get<Product>($"api/product/{id}");
        }

        public async Task DeleteProduct(int id)
        {
            await _httpService.Delete($"api/product/{id}");
        }

        public async Task AddProduct([FromBody] Product product)
        {
            await _httpService.Post($"api/product", product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _httpService.Put($"api/product", product);
        }
    }
}