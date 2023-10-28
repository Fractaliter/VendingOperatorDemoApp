using System.Web.Http;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Client.Services
{
    public interface IProductService
    {
        Task AddProduct([FromBody] Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        Task<PagedResult<Product>> GetProducts(string name, string page);
        Task UpdateProduct(Product product);
    }
}