using FluentValidation;

namespace Inventory.API.Dtos.Category.Validators
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
    {

        public CreateCategoryValidator()
        {
            RuleFor(c => c.CategoryName)
                .Length(3, 100).WithMessage("min length 3 characters")
                .NotEmpty().WithMessage("can not be blank");
        }
    }
}
