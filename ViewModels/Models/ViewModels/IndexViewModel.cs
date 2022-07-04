using ViewModels.Models;

namespace ViewModels.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Person> People { get; set; } = new List<Person>();
        public List<CompanyModel> Companies { get; set; } = new List<CompanyModel>();
    }
}
