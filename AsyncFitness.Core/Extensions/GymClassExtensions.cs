using AsyncFitness.Core.Exceptions;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Extensions
{
    public static class GymClassExtensions
    {
        public static void GuardAgainstNull(this GymClass fitnessClass)
        {
            if (fitnessClass == null)
            {
                throw new GymClassException("GroupFitnessClass cannot be null.");
            }
        }

        public static void GuardAgainstInvalid(this GymClass fitnessClass)
        {
            if (!fitnessClass.IsValidTimeSlot())
            {
                throw new GymClassException($"GroupFitnessClass ID:{fitnessClass.Id} invalid Start and End Times. {fitnessClass.Start.ToShortTimeString()} - {fitnessClass.End.ToShortTimeString()}");
            }
            if (!fitnessClass.IsValidDuration())
            {
                throw new GymClassException($"GroupFitnessClass ID:{fitnessClass.Id} is not allocated enough time for its GroupFitnessConcept. Concept Duration: {fitnessClass.Concept.Duration}. Allocated GroupfitnessClass Duration: {fitnessClass.End - fitnessClass.Start}");
            }

        }

        public static void GuardAgainstOverbooking(this GymClass fitnessClass)
        {
            if (!fitnessClass.IsValidCapacity())
            {
                throw new GymClassException($"GroupFitnessClass ID:{fitnessClass.Id} has too many bookings. Capacity: {fitnessClass.Location.Capacity}, Bookings: {fitnessClass.BookedParticipants.Count}");
            }
        }
        

        public static bool DoubleBooking(this GymClass fitnessClassOne, GymClass fitnessClassTwo)
        {
            if (fitnessClassOne.Location == fitnessClassTwo.Location)
            {
                return fitnessClassOne.Start < fitnessClassTwo.End
                    && fitnessClassTwo.Start < fitnessClassOne.End;
            }
            return false;
        }
    }
}
