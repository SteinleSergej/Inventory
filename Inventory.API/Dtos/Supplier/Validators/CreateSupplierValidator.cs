using FluentValidation;

namespace Inventory.API.Dtos.Supplier.Validators
{
    public class CreateSupplierValidator:AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("can not be blank");

            RuleFor(s => s.ContactInformation)
                .NotEmpty().WithMessage("can not be blank");
        }
    }
}
