using warehouse.Data.Models;

namespace warehouse.Data.Interfaces
{
    public interface IResources
    {
        IEnumerable<Resources> Resources { get; }
        IEnumerable<Resources> NotArchivResources { get; }
        IEnumerable<Resources> ArchivResources { get; }
        Resources GetResource(int ResourceId);
        void ChangeResource(Resources Resource);
        void DeleteResource(Resources Resource);
        bool doubleCheck(string name);
        void newResource(string name);
    }
}
