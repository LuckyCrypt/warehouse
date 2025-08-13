using warehouse.Data.Models;

namespace warehouse.Data.Interfaces
{
    public interface IClients
    {
        IEnumerable<Clients> Clients { get; }
        IEnumerable<Clients> NotArchivClients { get; }
        IEnumerable<Clients> ArchivClients { get; }
        Clients GetClient(int ClientId);
        void ChangeClient(Clients Client);
        void DeleteClient(Clients Client);
        bool doubleCheck(string name);
        void newClient(string name,string Address);
    }
}
