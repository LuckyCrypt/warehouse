using Microsoft.EntityFrameworkCore;
using System.Net;
using warehouse.Data;
using warehouse.Data.Interfaces;
using warehouse.Data.Models;

namespace warehouse.Repository
{
    public class ClientsRepository : IClients
    {
        private readonly AppDbContext appDbContext;

        public ClientsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Clients> Clients => appDbContext.Clients;

        public IEnumerable<Clients> NotArchivClients => appDbContext.Clients.Where(d => !d.IsArchived);

        public IEnumerable<Clients> ArchivClients => appDbContext.Clients.Where(d => d.IsArchived);

        public Clients GetClient(int ClientId) => appDbContext.Clients.FirstOrDefault(p => p.Id == ClientId);

        public void ChangeClient(Clients Client)
        {
            appDbContext.Update(Client);
            appDbContext.SaveChanges();
        }

        public void DeleteClient(Clients Client)
        {
            appDbContext.Remove(Client);
            appDbContext.SaveChanges();
        }

        public bool doubleCheck(string name)
        {
            if (appDbContext.Clients.FirstOrDefault(i => i.Name == name) != null ? true : false)
                return true;
            else return false;

        }

        public void newClient(string name,string Address)
        {
            Clients addnew = new Clients();
            addnew.Name = name;
            addnew.Address = Address;
            appDbContext.Clients.Add(addnew);
            appDbContext.SaveChanges();
        }
    }
}
