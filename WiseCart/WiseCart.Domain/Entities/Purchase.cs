namespace WiseCart.Domain.Entities
{
    public class Purchase : Entity
    {
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; }

        public Guid UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid ShoppingId { get; set; }
        public Shopping Shopping { get; set; }

    }
}
