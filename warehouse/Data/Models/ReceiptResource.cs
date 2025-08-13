using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse.Data.Models
{
    public class ReceiptResource : BaseEntity
    {
        public int ReceiptDocumentId { get; set; }
        public ReceiptDocument ReceiptDocument { get; set; }
        public int ResourceId { get; set; }
        public Resources Resource { get; set; }
        public int UnitId { get; set; }
        public Units Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
