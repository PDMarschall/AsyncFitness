using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.Facility
{
    public class GymLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Display(Name = "Location")]
        public string Name { get; set; }

        [Required, Display(Name="Capacity")]
        public int Capacity { get; set; }

        [Required]
        public Gym Center { get; set; }

        public List<GymClass> Classes { get; set; } = new List<GymClass>();
    }
}
