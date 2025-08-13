using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse.Data.Models
{
    public class StockBalance : BaseEntity
    {
        public int ResourceId { get; set; }
        public Resources Resource { get; set; }
        public int UnitId { get; set; }
        public Units Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
