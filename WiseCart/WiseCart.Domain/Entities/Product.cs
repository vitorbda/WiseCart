namespace WiseCart.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brands { get; set; }
    }
}
