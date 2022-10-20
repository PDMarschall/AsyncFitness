using AsyncFitness.Core.Models;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AsyncFitness.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<AsyncFitnessUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, UserManager<AsyncFitnessUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

    }
}