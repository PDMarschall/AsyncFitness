using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Exceptions
{
    internal class GymClassException : Exception
    {
        public GymClassException()
        {
        }

        public GymClassException(string? message) : base(message)
        {
        }

        public GymClassException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GymClassException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
