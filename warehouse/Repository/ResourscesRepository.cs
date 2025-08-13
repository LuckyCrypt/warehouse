using Microsoft.EntityFrameworkCore;
using warehouse.Data;
using warehouse.Data.Interfaces;
using warehouse.Data.Models;


namespace warehouse.Repository
{
    public class ResourscesRepository : IResources
    {

        private readonly AppDbContext appDbContext;

        public ResourscesRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Resources> Resources => appDbContext.Resources;

        public IEnumerable<Resources> NotArchivResources => appDbContext.Resources.Where(d => !d.IsArchived);

        public IEnumerable<Resources> ArchivResources => appDbContext.Resources.Where(d => d.IsArchived);

        public Resources GetResource(int ResourceId) => appDbContext.Resources.FirstOrDefault(p => p.Id == ResourceId);

        public void ChangeResource(Resources Resource)
        {
            appDbContext.Update(Resource);
            appDbContext.SaveChanges();
        }

        public void DeleteResource(Resources Resource)
        {
            appDbContext.Remove(Resource);
            appDbContext.SaveChanges();
        }

        public bool doubleCheck(string name)
        {
            if (appDbContext.Resources.FirstOrDefault(i => i.Name == name) != null ? true : false)
                return true;
            else return false;

        }

        public void newResource(string name)
        {
            Resources addnew = new Resources();
            addnew.Name = name;
            appDbContext.Resources.Add(addnew);
            appDbContext.SaveChanges();
        }
    }
}
