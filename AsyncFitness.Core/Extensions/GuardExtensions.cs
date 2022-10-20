using AsyncFitness.Core.Exceptions;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Extensions
{
    public static class GuardExtensions
    {
        public static void GuardAgainstNull(this object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException($"{nameof(obj)} cannot be null.");
            }
        }

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
    }
}
