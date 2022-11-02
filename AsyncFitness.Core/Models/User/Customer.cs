using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.User
{
    public class Customer : UserBase
    {
        public Subscription? Subscription { get; set; }
        public Trainer? Trainer { get; set; }

        public List<GymClass> BookedClasses { get; set; }
    }
}
