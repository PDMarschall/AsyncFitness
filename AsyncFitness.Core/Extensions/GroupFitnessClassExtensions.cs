using AsyncFitness.Core.Exceptions;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Extensions
{
    public static class GroupFitnessClassExtensions
    {
        public static void GuardAgainstNull(this GroupFitnessClass fitnessClass)
        {
            if (fitnessClass == null)
            {
                throw new GroupFitnessClassException("GroupFitnessClass cannot be null.");
            }
        }

        public static void GuardAgainstInvalid(this GroupFitnessClass fitnessClass)
        {
            if (!fitnessClass.IsValid())
            {
                throw new GroupFitnessClassException($"GroupFitnessClass ID:{fitnessClass.Id} did not pass internal class validity test.");
            }
        }

        public static bool DoubleBooking(this GroupFitnessClass fitnessClassOne, GroupFitnessClass fitnessClassTwo)
        {
            if (fitnessClassOne.Location == fitnessClassTwo.Location)
            {
                return fitnessClassOne.Start >= fitnessClassTwo.End && fitnessClassOne.End <= fitnessClassTwo.Start;
            }
            return false;
        }
    }
}
