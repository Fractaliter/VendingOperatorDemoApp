using FluentValidation;

namespace Blazorcrud.Shared.Models
{
    public class VendingMachineValidator : AbstractValidator<VendingMachine>
    {
        public VendingMachineValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(vendingMachine => vendingMachine.VendingMachineName).NotEmpty().WithMessage("Vending Machine Name is a required field.")
                .Length(3, 50).WithMessage("Vending Machine Name must be between 3 and 50 characters."); 
        }
    }
}