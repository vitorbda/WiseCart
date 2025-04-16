using System.ComponentModel;

namespace WiseCart.Front.Models.ViewModel
{
    public class PurchaseViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Preço")]
        public Decimal Price { get; set; } = 0;
        public Decimal Quantity { get; set; } = 1;
        [DisplayName("Quantidade")]
        public string _quantity => ((int)Math.Round(Quantity)).ToString();
        public Guid UnitOfMeasureId { get; set; }
        [DisplayName("Unidade de medida")]
        public string UnitOfMeasure_Abbreviation { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public string _product_Name => Product?.Name ?? string.Empty;
        public Guid ShoppingId { get; set; }

        [DisplayName("Total")]
        public string _valorTotal => (UnitOfMeasure_Abbreviation.ToLower() == "un" ? Quantity * Price : Price).ToString("N2");
        public string Brand => Product.Brands;
        public bool _shoppingIsActive { get; set; } = false;
    }
}
