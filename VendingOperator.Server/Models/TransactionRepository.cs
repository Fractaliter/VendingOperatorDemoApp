using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace VendingOperator.Server.Models
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        public TransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Transaction> AddTransaction(Transaction Transaction)
        {
            var result = await _appDbContext.Transactions.AddAsync(Transaction);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction?> DeleteTransaction(int TransactionId)
        {
            var result = await _appDbContext.Transactions.FirstOrDefaultAsync(p => p.TransactionId == TransactionId);
            if (result != null)
            {
                _appDbContext.Transactions.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Transaction not found");
            }
            return result;
        }

        public async Task<Transaction?> GetTransaction(int TransactionId)
        {
            var result = await _appDbContext.Transactions
                .FirstOrDefaultAsync(p => p.TransactionId == TransactionId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Transaction not found");
            }
        }

        public PagedResult<Transaction> GetTransactions(string? TransactionName, int page)
        {
            int pageSize = 5;

            if (TransactionName != null)
            {
                return _appDbContext.Transactions
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.Transactions
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Transaction?> UpdateTransaction(Transaction Transaction)
        {
            var result = await _appDbContext.Transactions.FirstOrDefaultAsync(p => p.TransactionId == Transaction.TransactionId);
            if (result != null)
            {
                // Update existing Transaction
                _appDbContext.Entry(result).CurrentValues.SetValues(Transaction);


                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Transaction not found");
            }
            return result;
        }
    }
}