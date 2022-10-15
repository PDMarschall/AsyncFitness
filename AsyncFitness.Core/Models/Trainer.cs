using AsyncFitness.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models
{
    public class Trainer : User
    {
        public List<Customer> Clients { get; set; } = new List<Customer>();
    }
}
