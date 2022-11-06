using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Extensions;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Globalization;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class ClassBookingModel : PageModel
    {
        private readonly IGymCalendarService _calendarService;
        private readonly IDomainRepository<Customer> _customerRepo;

        [BindProperty(SupportsGet = true)]
        public GymCalendarWeekDto CalendarWeek { get; set; }

        public ClassBookingModel(IGymCalendarService calendarService, IDomainRepository<Customer> customerRepo)
        {
            _calendarService = calendarService;
            _customerRepo = customerRepo;
        }

        public async Task OnGetAsync(int year, int week)
        {            
            var user = await _customerRepo.FindAsync(c => c.Email == User.Identity.Name);
            CalendarWeek = _calendarService.LoadCalendarWeek(DateTimeExtensions.FirstDateOfWeekISO8601(year, week), user.First());
        }
    }
}
