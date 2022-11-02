using AsyncFitness.Core.DTOs.GroupFitnessClassDTOs;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGroupFitnessClassBookingService _bookingService;        
        private readonly IRepository<Customer> _customerRepo;

        public IndexModel(IGroupFitnessClassBookingService bookingService, IRepository<Customer> customerRepo)
        {
            _bookingService = bookingService;            
            _customerRepo = customerRepo;
        }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<GroupFitnessClassBookingListDto> UserBookings { get; set; }
        public int ClassId { get; set; }

        public async Task OnGetAsync()
        {
            await LoadBookings();
        }

        private async Task LoadBookings()
        {
            IEnumerable<Customer> customerResult = await _customerRepo.FindAsync(c => c.Email == User.Identity.Name);

            UserBookings = await _bookingService.LoadClassesAsync(customerResult.First());
        }
    }
}
