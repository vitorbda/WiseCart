using FluentValidation;

namespace WiseCart.Application.DTOs.Validators
{
    public class UnitOfMeasureDTOValidator : AbstractValidator<UnitOfMeasureDTO>
    {
        public UnitOfMeasureDTOValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters")
                .MaximumLength(50).WithMessage("Name must be no more than 50 characters");

            RuleFor(u => u.Abbreviation)
                .NotEmpty().WithMessage("Abbreviation is required")
                .MinimumLength(1).WithMessage("Abbreviation must have at least 1 character")
                .MaximumLength(10).WithMessage("Abbreviation must be no more than 10 characters");
        }
    }
}
