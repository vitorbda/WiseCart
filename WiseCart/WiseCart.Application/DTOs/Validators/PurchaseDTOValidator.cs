using FluentValidation;

namespace WiseCart.Application.DTOs.Validators
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("ProductId is required");

            RuleFor(p => p.UnitOfMeasureId)
                .NotEmpty().WithMessage("UnitOfMeasureId is required");

            RuleFor(p => p.ShoppingId)
                .NotEmpty().WithMessage("ShoppingId is required");
        }
    }
}
