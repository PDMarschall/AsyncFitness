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
    public static class GymClassBookingOverviewSelectDto
    {
        public static IQueryable<GymClassBookingOverviewDto> MapGroupFitnessClassToListDto(this IQueryable<GymClass> fitnessClasses, Customer customer)
        {
            return fitnessClasses.Where(c => c.BookedParticipants.Contains(customer)).Select(groupfitnessclass => new GymClassBookingOverviewDto
            {
                GroupFitnessClassId = groupfitnessclass.Id,
                ConceptName = groupfitnessclass.Concept.Name,
                LocationName = groupfitnessclass.Location.Name,
                InstructorNames = groupfitnessclass.Instructors.Select(i => i.FirstName + " " + i.LastName),
                Time = string.Format("{0:d. MMMM HH:mm}", groupfitnessclass.Start)
            });
        }

        public static IQueryable<GymClassBookingOverviewDto> MapGroupFitnessClassToListDto(this IQueryable<GymClass> fitnessClasses, int fitnessClassId)
        {
            return fitnessClasses.Where(c => c.Id == fitnessClassId).Select(groupfitnessclass => new GymClassBookingOverviewDto
            {
                GroupFitnessClassId = groupfitnessclass.Id,
                ConceptName = groupfitnessclass.Concept.Name,
                LocationName = groupfitnessclass.Location.Name,
                InstructorNames = groupfitnessclass.Instructors.Select(i => i.FirstName + " " + i.LastName),
                Time = string.Format("{0:d. MMMM HH:mm}", groupfitnessclass.Start)
            });
        }
    }
}