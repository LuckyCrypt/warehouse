using warehouse.Data.Models;

namespace warehouse.ViewModel
{
    public class UnitsViewModel
    {
        public IEnumerable<Units> GetUnits {  get; set; }
        public Units GetSomeUnits { get; set; }
    }
}
