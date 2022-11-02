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
    public class GymClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<Customer> BookedParticipants { get; set; } = new List<Customer>();

        [Required]
        public List<Trainer> Instructors { get; set; } = new List<Trainer>();

        [Required]
        public GymLocation Location { get; set; } = new GymLocation();

        [Required]
        public GymClassConcept Concept { get; set; } = new GymClassConcept();

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public bool IsValidTimeSlot()
        {
            return Start < End;
        }

        public bool IsValidDuration()
        {
            return End - Start >= Concept.Duration;
        }

        public bool IsValidCapacity()
        {
            return BookedParticipants.Count() >= Location.Capacity;
        }
    }
}
