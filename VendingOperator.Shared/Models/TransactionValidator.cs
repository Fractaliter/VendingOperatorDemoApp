using FluentValidation;

namespace VendingOperator.Shared.Models
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}