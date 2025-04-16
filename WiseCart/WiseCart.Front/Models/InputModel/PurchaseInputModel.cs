using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using WiseCart.Front.Models.ViewModel;

namespace WiseCart.Front.Models.InputModel
{
    public class PurchaseInputModel
    {
        public Guid Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Price { get; set; } = 0;
        public Decimal Quantity { get; set; } = 1;
        public int UnitOfMeasureId { get; set; }
        public int ProductId { get; set; }
        public int ShoppingId { get; set; }
    }
}
