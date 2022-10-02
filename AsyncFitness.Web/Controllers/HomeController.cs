﻿using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsyncFitness.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<GymCustomer> _repository;

        public HomeController(ILogger<HomeController> logger, IRepository<GymCustomer> repository)
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

        [HttpPost]
        public IActionResult Login(GymCustomer temp, string pwText)
        {
            GymCustomer customer = _repository.Get(temp.Email);
            
            if (customer.ValidatePassword(pwText))
            {
            return View("LandingPage", customer);
            }

            return View("Index");
        }

        public IActionResult Account(GymCustomer signedInUser)
        {
            return View(signedInUser);
        }
    }
}
