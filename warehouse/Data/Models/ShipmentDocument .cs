using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse.Data.Models
{
    public class ShipmentDocument : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public bool IsSigned { get; set; } = false;
        public int? ClientId { get; set; }
        public Clients Client { get; set; }
        public ICollection<ShipmentResource> ShipmentResources { get; set; }
    }
}
