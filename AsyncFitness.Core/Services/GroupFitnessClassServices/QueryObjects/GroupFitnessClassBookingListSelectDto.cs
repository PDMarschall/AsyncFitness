using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Services.GroupFitnessClassServices.QueryObjects
{
    public static class GroupFitnessClassBookingListSelectDto
    {
        public static IQueryable<GroupFitnessClassBookingListDto> MapGroupFitnessClassToDto(this IQueryable<GroupFitnessClass> fitnessClasses, string userEmail)
        {
            return fitnessClasses.Select(groupfitnessclass => new GroupFitnessClassBookingListDto
            {
                Conceptname = groupfitnessclass.Concept.Name,
                LocationName = groupfitnessclass.Location.Name,
                InstructorNames = groupfitnessclass.Instructors.Select(i => i.FirstName + i.LastName),
                Time = string.Format("{0:d MMMM HH:mm}", groupfitnessclass.Start),       
                OnWaitingList = groupfitnessclass.Location.Capacity > groupfitnessclass.BookedParticipants.FindIndex(i => i.Email == userEmail),
                NumberInWaitingList = groupfitnessclass.Location.Capacity - groupfitnessclass.BookedParticipants.FindIndex(i => i.Email == userEmail)
            });
        }
    }
}
