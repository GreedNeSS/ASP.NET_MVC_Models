using Microsoft.AspNetCore.Mvc;
using Introduction.Models;

namespace Introduction.Controllers
{
    public class HomeController : Controller
    {
        List<Person> people = new List<Person>()
        {
            new Person(1, "GreedNeSS", 30),
            new Person(2, "Marcus", 45),
            new Person(3, "Henry", 24),
        };

        public IActionResult Index()
        {
            return View(people);
        }
    }
}
