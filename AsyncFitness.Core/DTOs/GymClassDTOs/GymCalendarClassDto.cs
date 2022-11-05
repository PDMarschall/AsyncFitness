using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.DTOs.GymClassDTOs
{
    public class GymCalendarClassDto
    {
        public int GroupFitnessClassId { get; set; }
        public string ConceptName { get; set; }
        public string LocationName { get; set; }
        public IEnumerable<string> InstructorNames { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Capacity { get; set; }
        public bool AlreadyBooked { get; set; }
    }
}
