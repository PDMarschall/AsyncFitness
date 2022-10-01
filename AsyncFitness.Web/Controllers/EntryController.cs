using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsyncFitness.Web.Controllers
{
    public class EntryController : Controller
    {
        private readonly ILogger<EntryController> _logger;
        private readonly IRepository<GymCustomer> _repository;

        public EntryController(ILogger<EntryController> logger, IRepository<GymCustomer> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GymCustomer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Add(customer);
                    _repository.SaveChanges();
                    return View("LandingPage", customer);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View();
            
        }

        public IActionResult Login()
        {
            var lars = _repository.Find(c => c.Email == "test@testmail.com");
            var larsobjekt = lars.First();
            var test = _repository.Count;
            return View("LandingPage", larsobjekt);
        }
    }
}
