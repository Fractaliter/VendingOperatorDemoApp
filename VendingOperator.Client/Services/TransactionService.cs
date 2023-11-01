using VendingOperator.Client.Shared;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;
using System.Web.Http;

namespace VendingOperator.Client.Services
{
    public class TransactionService : ITransactionService
    {
        private IHttpService _httpService;

        public TransactionService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResult<Transaction>> GetTransactions(string? name, string page)
        {
            return await _httpService.Get<PagedResult<Transaction>>("api/transaction" + "?page=" + page + "&name=" + name);
        }

        public async Task<Transaction> GetTransaction(int id)
        {
            return await _httpService.Get<Transaction>($"api/transaction/{id}");
        }

        public async Task DeleteTransaction(int id)
        {
            await _httpService.Delete($"api/transaction/{id}");
        }

        public async Task AddTransaction([FromBody] Transaction Transaction)
        {
            await _httpService.Post($"api/transaction", Transaction);
        }

        public async Task UpdateTransaction(Transaction Transaction)
        {
            await _httpService.Put($"api/transaction", Transaction);
        }
    }
}