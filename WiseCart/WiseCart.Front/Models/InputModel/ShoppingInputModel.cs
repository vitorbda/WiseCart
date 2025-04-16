using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WiseCart.Front.Models.ViewModel;

namespace WiseCart.Front.Models.InputModel
{
    public class ShoppingInputModel
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Selecione um mercado")]
        public Guid MarketId { get; set; }
        [JsonIgnore]
        public IEnumerable<MarketViewModel> Markets { get; set; } = new List<MarketViewModel>();
    }
}
