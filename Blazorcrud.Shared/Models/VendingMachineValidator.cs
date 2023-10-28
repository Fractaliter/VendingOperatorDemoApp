using FluentValidation;

namespace VendingOperator.Shared.Models
{
    public class VendingMachineValidator : AbstractValidator<VendingMachine>
    {
        public VendingMachineValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(vendingMachine => vendingMachine.VendingMachineName).NotEmpty().WithMessage("Vending Machine Name is a required field.")
                .Length(3, 50).WithMessage("Vending Machine Name must be between 3 and 50 characters.");
            RuleFor(vendingMachine => vendingMachine.VendingMachineStatus).NotEmpty().WithMessage("VendingMachineStatus is a required field.")
                .Length(3, 50).WithMessage("VendingMachineStatus must be between 3 and 50 characters.");
            RuleFor(vendingMachine => vendingMachine.Location).NotEmpty().WithMessage("Location is a required field.")
                .WithMessage("Location is a required field.");
            RuleFor(vendingMachine => vendingMachine.Capacity).NotNull().WithMessage("Phone number must be between 5 and 50 characters.");
        }
    }
}