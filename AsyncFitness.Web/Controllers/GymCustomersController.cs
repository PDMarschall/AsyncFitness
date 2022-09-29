using Microsoft.AspNetCore.Mvc;

namespace AsyncFitness.Web.Controllers
{
    public class GymCustomersController : Controller
    {
        private readonly ILogger<GymCustomersController> _logger;

        public GymCustomersController(ILogger<GymCustomersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
