using FluentValidation;

namespace VendingOperator.Shared.Models
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            CascadeMode = CascadeMode.Stop;

        }
    }
}