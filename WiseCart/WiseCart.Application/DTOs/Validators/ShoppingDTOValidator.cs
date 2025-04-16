using FluentValidation;

namespace WiseCart.Application.DTOs.Validators
{
    public class ShoppingDTOValidator : AbstractValidator<ShoppingDTO>
    {
        public ShoppingDTOValidator()
        {
            /*RuleFor(s => s.DateEnd)
                .GreaterThan(s => s.DateStart).WithMessage("DateEnd must be greater than DateStart");

            RuleFor(s => s.UserId)
                .NotEmpty().WithMessage("UserId is required");

            RuleFor(s => s.MarketId)
                .NotEmpty().WithMessage("MarketId is required");

            RuleFor(s => s.Purchases)
                .NotEmpty().WithMessage("Purchases is required");*/
        }
    }
}
