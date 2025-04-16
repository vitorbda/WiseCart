using System.ComponentModel;

namespace WiseCart.Front.Models.ViewModel
{
    public class MarketViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
    }
}
