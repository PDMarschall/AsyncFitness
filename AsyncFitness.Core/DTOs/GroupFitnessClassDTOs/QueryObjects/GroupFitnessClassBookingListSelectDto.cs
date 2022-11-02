using AsyncFitness.Core.DTOs.GroupFitnessClassDTOs;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.DTOs.GroupFitnessClassDTOs.QueryObjects
{
    public static class GroupFitnessClassBookingListSelectDto
    {
        public static IQueryable<GroupFitnessClassBookingListDto> MapGroupFitnessClassToDto(this IQueryable<GroupFitnessClass> fitnessClasses, Customer customer)
        {
            return fitnessClasses.Where(c => c.BookedParticipants.Contains(customer)).Select(groupfitnessclass => new GroupFitnessClassBookingListDto
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