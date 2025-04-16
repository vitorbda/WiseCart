using FluentValidation;

namespace WiseCart.Application.DTOs.Validators
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("Code is required")
                .MaximumLength(20).WithMessage("Code must be no more than 20 characters")
                .MinimumLength(5).WithMessage("Code must have at least 5 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name must be no more than 50 characters")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters");

            RuleFor(p => p.Brands)
                .MaximumLength(30).WithMessage("Brands must be no more than 50 characters");
        }
    }
}
