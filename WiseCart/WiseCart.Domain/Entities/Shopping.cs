namespace WiseCart.Domain.Entities
{
    public class Shopping : Entity
    {
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid MarketId { get; set; }
        public Market Market { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
