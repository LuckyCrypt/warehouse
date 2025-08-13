using System.ComponentModel.DataAnnotations;

namespace warehouse.Data.Models
{
    public class ReceiptDocument : BaseEntity
    {
        public int Number { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public ICollection<ReceiptResource> ReceiptResources { get; set; }
    }
}
