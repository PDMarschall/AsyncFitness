using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.User
{
    public class Admin : UserBase
    {
        public List<FitnessCenter> AdministratedFitnessCenters { get; set; }
    }
}
