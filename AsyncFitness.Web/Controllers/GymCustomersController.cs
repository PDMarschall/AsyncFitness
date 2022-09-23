using Microsoft.AspNetCore.Mvc;

namespace AsyncFitness.Web.Controllers
{
    public class GymCustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
