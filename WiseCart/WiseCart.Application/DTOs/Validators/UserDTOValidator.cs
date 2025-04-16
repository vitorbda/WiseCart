using FluentValidation;

namespace WiseCart.Application.DTOs.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters")
                .MaximumLength(50).WithMessage("Name must be no more than 50 characters");

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("UserName is required")
                .MinimumLength(6).WithMessage("UserName must have at least 6 characters")
                .MaximumLength(15).WithMessage("UserName must be no more than 15 characters");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is invalid");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must have at least 8 characters")
                .MaximumLength(60).WithMessage("Password must be no more than 60 characters");

            RuleFor(u => u.Role)
                .NotEmpty().WithMessage("Role is required")
                .MinimumLength(3).WithMessage("Role must have at least 3 characters")
                .MaximumLength(20).WithMessage("Role must be no more than 20 characters");
        }
    }
}
