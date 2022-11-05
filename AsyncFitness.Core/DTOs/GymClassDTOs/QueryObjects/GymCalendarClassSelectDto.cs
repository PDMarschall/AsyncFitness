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
    public static class GymCalendarClassSelectDto
    {
        public static IQueryable<GymCalendarClassDto> MapGroupFitnessClassToCalendarDto(this IQueryable<GymClass> fitnessClasses, Customer customer)
        {
            return fitnessClasses.Select(groupfitnessclass => new GymCalendarClassDto
            {
                GroupFitnessClassId = groupfitnessclass.Id,
                ConceptName = groupfitnessclass.Concept.Name,
                LocationName = groupfitnessclass.Location.Name,
                InstructorNames = groupfitnessclass.Instructors.Select(i => i.FirstName + " " + i.LastName),
                Start = groupfitnessclass.Start,
                End = groupfitnessclass.End,
                Capacity = groupfitnessclass.Location.Capacity,
                AlreadyBooked = groupfitnessclass.BookedParticipants.Contains(customer)
            });
        }
    }
}
