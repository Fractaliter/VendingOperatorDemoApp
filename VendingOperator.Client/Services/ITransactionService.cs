using System.Web.Http;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Client.Services
{
    public interface ITransactionService
    {
        Task AddTransaction([FromBody] Transaction person);
        Task DeleteTransaction(int id);
        Task<Transaction> GetTransaction(int id);
        Task<PagedResult<Transaction>> GetTransactions(string name, string page);
        Task UpdateTransaction(Transaction Transaction);
    }
}