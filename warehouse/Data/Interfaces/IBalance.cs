using warehouse.Data.Models;

namespace warehouse.Data.InterfacesStockBalance
{
    public interface IBalance
    {
        IEnumerable<StockBalance> Balance { get; }
    }
}
