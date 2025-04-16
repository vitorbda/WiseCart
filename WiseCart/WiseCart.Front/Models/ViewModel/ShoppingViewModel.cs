using System.ComponentModel;

namespace WiseCart.Front.Models.ViewModel
{
    public class ShoppingViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateStart { get; set; }

        [DisplayName("Data de início")]
        public string _dateStart => DateStart.ToString("dd/MM/yyyy HH:mm");
        public DateTime? DateEnd { get; set; }

        [DisplayName("Data de fim")]
        public string _dateEnd => DateEnd?.ToString("dd/MM/yyyy HH:mm") ?? "Em andamento";

        public MarketViewModel Market { get; set; }
        [DisplayName("Mercado")]
        public string _market_Name => Market?.Name ?? string.Empty;

        public IEnumerable<PurchaseViewModel> Purchases { get; set; }
        [DisplayName("Quantidade de itens")]
        public string _quantityItens
        {
            get
            {
                var total = Purchases.Sum(p => p.UnitOfMeasure_Abbreviation.ToLower() == "un" ? p.Quantity : 1);
                var totalInt = (int)total;

                return totalInt.ToString();
            }
        }

        [DisplayName("Total")]
        public string _valorTotal => Purchases.Sum(p => p.UnitOfMeasure_Abbreviation.ToLower() == "un" ? p.Quantity * p.Price : p.Price).ToString("N2");

        public bool _active => DateEnd is null;
    }
}
