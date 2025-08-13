namespace warehouse.Data.Models
{
    public class ShipmentResource : BaseEntity
    {
        public int ShipmentDocumentId { get; set; }
        public ShipmentDocument ShipmentDocument { get; set; }
        public int ResourceId { get; set; }
        public Resources Resource { get; set; }
        public int UnitId { get; set; }
        public Units Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
