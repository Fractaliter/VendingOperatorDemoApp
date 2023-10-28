using VendingOperator.Server.Authorization;
using VendingOperator.Server.Models;
using VendingOperator.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace VendingOperator.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        /// <summary>
        /// Returns a list of paginated Products with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetProducts([FromQuery] string? name, int page)
        {
            return Ok(_ProductRepository.GetProducts(name, page));
        }

        /// <summary>
        /// Gets a specific Product by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            return Ok(await _ProductRepository.GetProduct(id));
        }

        /// <summary>
        /// Creates a Product with child addresses.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product Product)
        {
            return Ok(await _ProductRepository.AddProduct(Product));
        }
        
        /// <summary>
        /// Updates a Product with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product Product)
        {
            return Ok(await _ProductRepository.UpdateProduct(Product));
        }

        /// <summary>
        /// Deletes a Product with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            return Ok(await _ProductRepository.DeleteProduct(id));
        }
    }
}
