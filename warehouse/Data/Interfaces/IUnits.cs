using warehouse.Data.Models;

namespace warehouse.Data.Interfaces
{
    public interface IUnits
    {
        IEnumerable<Units> Units { get; }
        IEnumerable<Units> NotArchivUnits { get; }
        IEnumerable<Units> ArchivUnits { get; }
        Units GetUnit(int unitId);
        void ChangeUnit(Units unit);
        void DeleteUnit(Units unit);
        bool doubleCheck(string name);
        void newUnit(string name);
    }
}
