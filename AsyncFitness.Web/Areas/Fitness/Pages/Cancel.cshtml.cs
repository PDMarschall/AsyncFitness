using AsyncFitness.Core.DTOs.GroupFitnessClassDTOs;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class CancelModel : PageModel
    {
        private readonly IGroupFitnessClassBookingService _bookingService;

        public GroupFitnessClassBookingListDto BookingToConfirmCancel { get; set; }
        public GroupFitnessClass BookingToCancel { get; set; }
        public CancelModel(IGroupFitnessClassBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookingToConfirmCancel = await _bookingService.LoadClassAsync(id.Value);

            if (BookingToConfirmCancel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int result = await _bookingService.CancelBooking(id.Value, User.Identity.Name);

            if (result <= 0)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

    }
}
