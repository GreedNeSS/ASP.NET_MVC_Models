using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;
using ViewModels.Models.ViewModels;

namespace ViewModels.Controllers
{
    public class HomeController : Controller
    {
        List<Person> people;
        List<Company> companies;

        public HomeController()
        {
            Company microsoft = new Company(1, "Microsoft", "USA");
            Company yandex = new Company(2, "Yandex", "Russia");
            Company google = new Company(3, "Google", "USA");

            companies = new List<Company>()
            {
                microsoft, yandex, google
            };

            people = new List<Person>()
            {
                new Person(1, "GreedNeSS", 30, microsoft),
                new Person(2, "Marcus", 45, microsoft),
                new Person(3, "Gleb", 22, yandex),
                new Person(4, "Mihail", 33, yandex),
                new Person(5, "Henry", 21, google),
                new Person(6, "Alex", 46, google),
            };
        }

        public IActionResult Index(int? companyId)
        {
            List<CompanyModel> compModels= companies.Select(c => new CompanyModel(c.Id, c.Name)).ToList();
            compModels.Insert(0, new CompanyModel(0, "All"));
            IndexViewModel viewModel = new IndexViewModel()
            {
                Companies = compModels,
                People = people
            };

            if (companyId != null && companyId > 0)
            {
                viewModel.People = people.Where(p => p.Work.Id == companyId).ToList();
            }

            return View(viewModel);
        }
    }
}
