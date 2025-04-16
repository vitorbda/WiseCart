using FluentValidation;

namespace WiseCart.Application.DTOs.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(l => l.UserName)
                .NotEmpty().WithMessage("UserName is required")
                .MinimumLength(6).WithMessage("UserName must have at least 6 characters")
                .MaximumLength(15).WithMessage("UserName must be no more than 6 characters");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must have at least 8 characters")
                .MaximumLength(60).WithMessage("Password must be no more than 60 characters");
        }
    }
}
