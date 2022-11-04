using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.DTOs.GymClassDTOs.QueryObjects
{
    public static class GymClassBookingCalendarSelectDto
    {
        // to do adapt to this dto
        public static IQueryable<GymClassBookingCalendarDto> MapGroupFitnessClassToCalendarDto(this IQueryable<GymClass> fitnessClasses, Customer customer)
        {
            return fitnessClasses.Select(groupfitnessclass => new GymClassBookingCalendarDto
            {
                GroupFitnessClassId = groupfitnessclass.Id,
                ConceptName = groupfitnessclass.Concept.Name,
                LocationName = groupfitnessclass.Location.Name,
                InstructorNames = groupfitnessclass.Instructors.Select(i => i.FirstName + " " + i.LastName),
                Time = string.Format("{0:d. MMMM HH:mm}", groupfitnessclass.Start),
                Capacity = groupfitnessclass.Location.Capacity,
                AlreadyBooked = groupfitnessclass.BookedParticipants.Contains(customer)
            });
        }
    }
}
