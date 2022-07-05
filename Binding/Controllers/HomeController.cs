using Binding.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Binding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // https://localhost:7164/?name=Alice&age=23
        public string Index([FromQuery]Person person)
        {
            return $"Name: {person.Name}; Age: {person.Age}";
        }

        public string BindUser([FromQuery] User user)
        {
            if (ModelState.IsValid)
            {
                return $"User Page\nId: {user.Id}; Name: {user.Name}; Age: {user.Age}; HasRight: {user.HasRight}";
            }

            string errors = $"Errors count: {ModelState.ErrorCount}\nKeys:";

            foreach (var e in ModelState.Keys)
            {
                errors = $"{errors} {e};";
            }

            return errors;
        }
    }
}