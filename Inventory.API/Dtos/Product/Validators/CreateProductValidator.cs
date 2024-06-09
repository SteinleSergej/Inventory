using FluentValidation;

namespace Inventory.API.Dtos.Product.Validators
{
    public class CreateProductValidator:AbstractValidator<CreateProductDto>
    {

        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("product name can not be blank");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("product description can not be blank");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("price must be greater than zero");
        }
    }
}
