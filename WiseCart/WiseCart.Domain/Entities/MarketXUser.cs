namespace WiseCart.Domain.Entities
{
    public class MarketXUser : Entity
    {
        public Guid MarketId { get; set; }
        public Market Market { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
