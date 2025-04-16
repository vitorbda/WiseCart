namespace WiseCart.Front.Models.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Brands { get; set; } = string.Empty;
    }
}
