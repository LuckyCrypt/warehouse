using warehouse.Data.Models;

namespace warehouse.ViewModel
{
    public class ClientsViewModel
    {
        public IEnumerable<Clients> GetClients { get; set; }
        public Clients GetSomeClients { get; set; }
    }
}
