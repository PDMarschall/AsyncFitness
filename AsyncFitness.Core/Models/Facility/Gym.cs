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
    public class Gym
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public Admin GymLeader { get; set; }

        public List<GymLocation> Facilities { get; set; } = new List<GymLocation>();

        public List<GymClassConcept> AvailableConcepts { get; set; } = new List<GymClassConcept>();
    }
}
