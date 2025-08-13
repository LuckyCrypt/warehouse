using Microsoft.AspNetCore.Mvc;
using warehouse.Data.Interfaces;
using warehouse.Data.InterfacesStockBalance;
using warehouse.Data.Models;
using warehouse.ViewModel;

namespace warehouse.Controllers
{
    public class BalancesController : Controller
    {
        private readonly IBalance _balance;
        private readonly IUnits _Units;
        private readonly IResources _Resources;


        public BalancesController(IBalance balance, IUnits units, IResources resources)
        {
            _balance = balance;
            _Units = units;
            _Resources = resources;
        }
        // GET: Balances
        public ActionResult Index()
        {
            try
            {
                BalanceViewModel model = new BalanceViewModel();
                model.GetBalance = _balance.Balance;
                IEnumerable<StockBalance> newitem = new List<StockBalance>();
/*                for (int i = 0; i < _balance.Balance.Count(); i++)
                {
                    var test = new List<StockBalance> { new StockBalance { Id = item.Id, IsArchived = item.IsArchived, Quantity = item.Quantity, Resource = _Resources.GetResource(item.ResourceId), ResourceId = item.ResourceId, Unit = _Units.GetUnit(item.UnitId), UnitId = item.UnitId }};      
                }*/

                return View(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
