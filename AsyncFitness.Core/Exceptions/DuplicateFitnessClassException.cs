using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Exceptions
{
    internal class DuplicateFitnessClassException : Exception
    {
        public DuplicateFitnessClassException()
        {
        }

        public DuplicateFitnessClassException(string? message) : base(message)
        {
        }

        public DuplicateFitnessClassException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicateFitnessClassException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
