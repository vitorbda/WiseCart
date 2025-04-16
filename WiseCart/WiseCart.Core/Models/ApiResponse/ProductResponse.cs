namespace WiseCart.Models.ApiResponse
{
    public class ProductResponse
    {
        public string Code { get; set; }
        public ProductDetails Product { get; set; }
        public int Status { get; set; }
        public string Status_verbose { get; set; }
    }
}
