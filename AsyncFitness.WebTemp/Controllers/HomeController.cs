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
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<Subscription> _subRepo;

        public HomeController(ILogger<HomeController> logger, IRepository<Customer> customerRepo, IRepository<Subscription> subRepo)
        {
            _logger = logger;
            _customerRepo = customerRepo;
            _subRepo = subRepo;
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
                    _customerRepo.Add(customer);
                    _customerRepo.SaveChanges();
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
            Customer customer = _customerRepo.Get(temp.Email);

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
            IQueryable<Subscription> subscriptions = _subRepo.All();
            ViewData["Subscriptions"] = subscriptions.Where(s => !s.Subscribers.Contains(customer));

            var temp = _customerRepo.Get(customer.Email);
            PassCustomerToLayout(temp);

            return View(temp);
        }

        [HttpPost]
        public IActionResult UpdateAccount(Customer customer, string sub)
        {
            IQueryable<Subscription> subscriptions = _subRepo.All();
            ViewData["Subscriptions"] = subscriptions.Where(s => !s.Subscribers.Contains(customer));

            if (ModelState.IsValid)
            {
                customer.Subscription = _subRepo.Get(sub);
                try
                {
                    _customerRepo.Update(customer);
                    _customerRepo.SaveChanges();
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
