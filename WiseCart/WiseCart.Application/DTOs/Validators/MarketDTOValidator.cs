using FluentValidation;

namespace WiseCart.Application.DTOs.Validators
{
    public class MarketDTOValidator : AbstractValidator<MarketDTO>
    {
        public MarketDTOValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters")
                .MaximumLength(30).WithMessage("Name must be no more than 30 characters");

            RuleFor(m => m.Street)
                .MinimumLength(5).WithMessage("Street must have at least 5 characters")
                .MaximumLength(50).WithMessage("Street must be no more than 50 characters");

            RuleFor(m => m.City)
                .MinimumLength(3).WithMessage("City must have at least 3 characters")
                .MaximumLength(30).WithMessage("City must be no more than 30 characters");

            RuleFor(m => m.State)
                .MinimumLength(5).WithMessage("State must have at least 2 characters")
                .MaximumLength(30).WithMessage("State must be no more than 30 characters");

            RuleFor(m => m.District)
                .MinimumLength(5).WithMessage("District must have at least 3 characters")
                .MaximumLength(30).WithMessage("District must be no more than 30 characters");
        }
    }
}
