using Microsoft.AspNetCore.Mvc;

namespace AsyncFitness.Web.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
