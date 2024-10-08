using FluentValidation;

namespace VendingOperator.Shared.Models
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            // Validate VendingMachineId
            RuleFor(transaction => transaction.VendingMachineId)
                .NotNull().WithMessage("Vending Machine must be selected.")
                .GreaterThan(0).WithMessage("Vending Machine ID must be greater than 0.");

            // Validate ProductId
            RuleFor(transaction => transaction.ProductId)
                .NotNull().WithMessage("Product must be selected.")
                .GreaterThan(0).WithMessage("Product ID must be greater than 0.");

            // Validate UserId
            RuleFor(transaction => transaction.UserId)
                .NotNull().WithMessage("User must be selected.")
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");

            // Validate Timestamp (should be a valid date and not in the future)
            RuleFor(transaction => transaction.Timestamp)
                .NotEmpty().WithMessage("Timestamp is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Transaction date cannot be in the future.");

        }
    }
}