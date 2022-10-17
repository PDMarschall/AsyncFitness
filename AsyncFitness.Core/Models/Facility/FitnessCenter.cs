using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Core.Datastructures;

namespace AsyncFitness.Core.Models.Facility
{
    public class FitnessCenter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Admin GymLeader { get; set; }

        public List<GroupFitnessLocation> Facilities { get; set; }

        public List<GroupFitnessConcept> AvailableClasses { get; set; }

        [NotMapped]
        public GroupFitnessClassCalendar ClassCalendar { get; set; }
    }
}
