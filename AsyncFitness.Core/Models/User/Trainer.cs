using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.User
{
    public class Trainer : UserBase
    {
        public List<Customer> Clients { get; set; } = new List<Customer>();

        public List<GymClassConcept> Certifications { get; set; }
        public List<GymClass> ClassesByTrainer { get; set; }
    }
}
