using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Exceptions
{
    internal class GroupFitnessClassException : Exception
    {
        public GroupFitnessClassException()
        {
        }

        public GroupFitnessClassException(string? message) : base(message)
        {
        }

        public GroupFitnessClassException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GroupFitnessClassException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
