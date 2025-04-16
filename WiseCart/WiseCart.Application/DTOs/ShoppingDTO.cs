namespace WiseCart.Application.DTOs
{
    public class ShoppingDTO
    {
        public Guid Id { get; set; }
        public DateTime DateStart { get; private set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; }
        public Guid UserId { get; set; }
        public Guid MarketId { get; set; }
        public MarketDTO? Market { get; set; }

        public IEnumerable<PurchaseDTO> Purchases { get; set; }
    }
}
