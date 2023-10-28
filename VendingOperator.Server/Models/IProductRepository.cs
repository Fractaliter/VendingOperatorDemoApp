using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Server.Models
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product Product);
        Task<Product?> DeleteProduct(int ProductId);
        Task<Product?> GetProduct(int ProductId);
        PagedResult<Product> GetProducts(string? name, int page);
        Task<Product?> UpdateProduct(Product Product);
    }
}