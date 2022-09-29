using Microsoft.AspNetCore.Mvc;

namespace AsyncFitness.Web.Controllers
{
    public class EntryController : Controller
    {
        private readonly ILogger<EntryController> _logger;

        public EntryController(ILogger<EntryController> logger)
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
