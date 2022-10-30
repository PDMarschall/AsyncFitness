using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.Facility
{
    public class GroupFitnessConcept
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50), Display(Name = "Concept")]
        public string Name { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public List<GroupFitnessClass> ClassesWithConcept { get; set; } = new List<GroupFitnessClass>();
        public List<FitnessCenter> CentersWithConcept { get; set; } = new List<FitnessCenter>();
    }
}
