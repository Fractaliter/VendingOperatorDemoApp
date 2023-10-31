using VendingOperator.Server.Authorization;
using VendingOperator.Server.Models;
using VendingOperator.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace VendingOperator.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _TransactionRepository;

        public TransactionController(ITransactionRepository TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;
        }

        /// <summary>
        /// Returns a list of paginated people with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetPeople([FromQuery] string? name, int page)
        {
            return Ok(_TransactionRepository.GetTransactions(name, page));
        }

        /// <summary>
        /// Gets a specific Transaction by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransaction(int id)
        {
            return Ok(await _TransactionRepository.GetTransaction(id));
        }

        /// <summary>
        /// Creates a Transaction with child addresses.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddTransaction(Transaction Transaction)
        {
            return Ok(await _TransactionRepository.AddTransaction(Transaction));
        }
        
        /// <summary>
        /// Updates a Transaction with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateTransaction(Transaction Transaction)
        {
            return Ok(await _TransactionRepository.UpdateTransaction(Transaction));
        }

        /// <summary>
        /// Deletes a Transaction with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            return Ok(await _TransactionRepository.DeleteTransaction(id));
        }
    }
}
