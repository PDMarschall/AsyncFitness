using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class ClassBookingModel : PageModel
    {
        private readonly IGymClassCalendarService _calendarService;
        private readonly IRepository<Customer> _customerRepo;

        [BindProperty(SupportsGet = true)]
        public GymClassCalendarWeekDto CalendarWeek { get; set; }

        public ClassBookingModel(IGymClassCalendarService calendarService, IRepository<Customer> customerRepo)
        {
            _calendarService = calendarService;
            _customerRepo = customerRepo;
        }

        public async Task OnGetAsync()
        {
            var user = await _customerRepo.FindAsync(c => c.Email == User.Identity.Name);
            CalendarWeek = _calendarService.LoadCalendarWeek(date: DateTime.Now, customer: user.First());
        }
    }
}
