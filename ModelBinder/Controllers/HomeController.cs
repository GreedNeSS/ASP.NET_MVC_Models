using Microsoft.AspNetCore.Mvc;
using ModelBinder.Models;
using System;

namespace ModelBinder.Controllers
{
    public class HomeController : Controller
    {
        static List<Event> events = new List<Event>();

        public IActionResult Index()
        {
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event myEvent)
        {
            events.Add(myEvent);
            return RedirectToAction("Index");
        }
    }
}
