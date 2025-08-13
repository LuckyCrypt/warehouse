using Microsoft.EntityFrameworkCore;
using warehouse.Data;
using warehouse.Data.Interfaces;
using warehouse.Data.Models;

namespace warehouse.Repository
{
    public class UnitsRepository : IUnits
    {
        private readonly AppDbContext appDbContext;

        public UnitsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Units> Units => appDbContext.Units;

        public IEnumerable<Units> NotArchivUnits => appDbContext.Units.Where(d => !d.IsArchived);

        public IEnumerable<Units> ArchivUnits => appDbContext.Units.Where(d => d.IsArchived);

        public Units GetUnit(int unitId) => appDbContext.Units.FirstOrDefault(p => p.Id == unitId);

        public void ChangeUnit(Units unit)
        {
            appDbContext.Update(unit);
            appDbContext.SaveChanges();
        }

        public void DeleteUnit(Units unit)
        {
            appDbContext.Remove(unit);
            appDbContext.SaveChanges();
        }

        public bool doubleCheck(string name)
        {
            if(appDbContext.Units.FirstOrDefault(i => i.Name == name)!=null?true:false)
                return true;
            else return false;

        }

        public void newUnit(string name)
        {
            Units addnew = new Units();
            addnew.Name = name;
            appDbContext.Units.Add(addnew);
            appDbContext.SaveChanges();
        }
    }
}
