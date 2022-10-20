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

        [Required]
        public List<Trainer> Instructors { get; set; }

        [Required]
        public GroupFitnessLocation Location { get; set; }

        [Required]
        public GroupFitnessConcept Concept { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public bool IsValidTimeSlot()
        {
            return Start < End;
        }

        public bool isValidDuration()
        {
            return End - Start >= Concept.Duration;
        }
    }
}
