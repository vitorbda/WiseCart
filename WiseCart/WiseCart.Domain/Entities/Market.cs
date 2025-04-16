namespace WiseCart.Domain.Entities
{
    public class Market : Entity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
    }
}
