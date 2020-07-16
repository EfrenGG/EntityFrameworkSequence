using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFrameworkSequence.Models;
using EntityFrameworkSequence.Models.Entities;
using EntityFrameworkSequence.Data.DB;
using EntityFrameworkSequence.Data;

namespace EntityFrameworkSequence.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonRepository _repo;

        public HomeController(ILogger<HomeController> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _repo = personRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var newPerson = new Person
            {
                FirstName = "Juan",
                LastName = "Pérez",
                PhoneNumber = "1234567890",
                EmailAddress = "jonhdoe@company.com",
                Password = "Admin1234!",
                LastUpdatedDate = DateTime.Now,
                LastUpdatedBy = "ADMIN"
            };
            var dbPerson = await _repo.CreatePersonAsync(newPerson);
            if (dbPerson != null)
            {
                _logger.LogInformation($"Persona con id {dbPerson.Id} creada correctamente!");
            }
            return View(dbPerson);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
