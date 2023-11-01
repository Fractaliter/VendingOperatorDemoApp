using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace VendingOperator.Server.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> AddProduct(Product Product)
        {
            var result = await _appDbContext.Products.AddAsync(Product);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product?> DeleteProduct(int ProductId)
        {
            var result = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (result != null)
            {
                _appDbContext.Products.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Product not found");
            }
            return result;
        }

        public async Task<Product?> GetProduct(int ProductId)
        {
            var result = await _appDbContext.Products
                .FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Product not found");
            }
        }

        public PagedResult<Product> GetProducts(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _appDbContext.Products
                    .Where(p => p.ProductName.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.Products
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Product?> UpdateProduct(Product Product)
        {
            var result = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == Product.ProductId);
            if (result != null)
            {
                // Update existing Product
                _appDbContext.Entry(result).CurrentValues.SetValues(Product);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Product not found");
            }
            return result;
        }
    }
}