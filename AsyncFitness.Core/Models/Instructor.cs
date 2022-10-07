using AsyncFitness.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models
{
    public class Instructor : User
    {
        public InstructorCertifications Certifications { get; set; } = new InstructorCertifications();
    }
}
