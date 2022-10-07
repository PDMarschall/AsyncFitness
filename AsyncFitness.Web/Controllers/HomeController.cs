using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace AsyncFitness.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Customer> _repository;
        private readonly FitnessBusinessContext context;

        public HomeController(ILogger<HomeController> logger, IRepository<Customer> repository, FitnessBusinessContext context)
        {
            _logger = logger;
            _repository = repository;
            this.context = context;
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
        public IActionResult Create(Customer customer)
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

        [HttpPost]
        public IActionResult Login(Customer temp, string pwText)
        {
            Customer customer = _repository.Get(temp.Email);

            if (customer != null && customer.ValidatePassword(pwText))
            {
                PassCustomerToLayout(customer);
                return View("LandingPage", customer);
            }

            return View("Index");
        }

        public IActionResult LandingPage(Customer customer)
        {
            PassCustomerToLayout(customer);
            return View(customer);
        }


        public IActionResult Account(Customer customer)
        {
            var temp = _repository.Get(customer.Email);
            PassCustomerToLayout(temp);
            return View(temp);
        }

        [HttpPost]
        public IActionResult UpdateAccount(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(customer);
                    _repository.SaveChanges();
                    PassCustomerToLayout(customer);
                    return View("Account", customer);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            PassCustomerToLayout(customer);
            return View(customer);
        }

        private void PassCustomerToLayout(Customer customer)
        {
            ViewData["sharedModel"] = customer;
        }
    }
}
