using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Server.Models
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransaction(Transaction Transaction);
        Task<Transaction?> DeleteTransaction(int TransactionId);
        Task<Transaction?> GetTransaction(int TransactionId);
        PagedResult<Transaction> GetTransactions(string? TransactionName, int page);
        Task<Transaction?> UpdateTransaction(Transaction Transaction);
    }
}