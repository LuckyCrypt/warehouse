using Microsoft.EntityFrameworkCore;
using warehouse.Data;
using warehouse.Data.InterfacesStockBalance;
using warehouse.Data.Models;

namespace warehouse.Repository
{
    public class BalanceRepository : IBalance
    {
        private readonly AppDbContext appDbContext;

        public BalanceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<StockBalance> Balance => appDbContext.StockBalances.Select(b => new StockBalance
        {
            Id = b.Id,
            Resource = appDbContext.Resources.FirstOrDefault(f => f.Id == b.ResourceId),
            ResourceId = b.ResourceId,
            Unit = appDbContext.Units.FirstOrDefault(f => f.Id == b.UnitId),
            UnitId = b.UnitId,
            IsArchived = b.IsArchived,
            Quantity = b.Quantity
        }).ToList();

    }
}
