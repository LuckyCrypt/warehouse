using warehouse.Data.Models;

namespace warehouse.ViewModel
{
    public class ResourcesViewModel
    {
        public IEnumerable<Resources> GetResources { get; set; }
        public Resources GetSomeResources { get; set; }
    }
}
