using System.ComponentModel;

namespace WiseCart.Front.Models.BaseModel
{
    public abstract class ShoppingBaseModel
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateStart { get; set; }

        [DisplayName("Data de início")]
        public string _dateStart => DateStart.ToString("dd/MM/yyyy hh:mm");
        public DateTime? DateEnd { get; set; }

        [DisplayName("Data de fim")]
        public string _dateEnd => DateEnd?.ToString("dd/MM/yyyy hh:mm") ?? "Em andamento";
    }
}
