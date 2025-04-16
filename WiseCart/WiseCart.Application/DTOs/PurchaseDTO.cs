using WiseCart.Domain.Entities;

namespace WiseCart.Application.DTOs
{
    public class PurchaseDTO
    {
        public Guid Id { get; set; }
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; }

        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasureDTO UnitOfMeasure { get; set; }
        public string UnitOFMeasure_Abbreviation => UnitOfMeasure?.Abbreviation ?? string.Empty;

        public Guid ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public Guid ShoppingId { get; set; }
        public ShoppingDTO Shopping { get; set; }
    }
}
