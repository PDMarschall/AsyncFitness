using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AsyncFitness.RPWeb.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<IdentityUser> _manager;

        public PrivacyModel(ILogger<PrivacyModel> logger, UserManager<IdentityUser> manager)
        {
            _logger = logger;
            _manager = manager;
        }

        public void OnGet()
        {
            ViewData["UserEmail"] = User.FindFirstValue(ClaimTypes.Name);
        }
    }
}