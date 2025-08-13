using warehouse.Data.Models;

namespace warehouse.ViewModel
{
    public class BalanceViewModel
    {
        public IEnumerable<StockBalance> GetBalance { get; set; }
        public StockBalance GetSomeBalance { get; set; }
    }
}
