using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.DTOs.GymClassDTOs
{
    public class GymClassBookingOverviewDto
    {
        public int GroupFitnessClassId { get; set; }
        public string ConceptName { get; set; }
        public string LocationName { get; set; }
        public IEnumerable<string> InstructorNames { get; set; }
        public string Time { get; set; }
    }
}
