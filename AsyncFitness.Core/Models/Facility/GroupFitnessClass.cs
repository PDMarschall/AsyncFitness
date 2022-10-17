using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncFitness.Core.Models.User;

namespace AsyncFitness.Core.Models.Facility
{
    public class GroupFitnessClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<Customer> BookedParticipants { get; set; }

        public List<Trainer> Instructors { get; set; }

        public GroupFitnessLocation Location { get; set; }

        public GroupFitnessConcept Concept { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
