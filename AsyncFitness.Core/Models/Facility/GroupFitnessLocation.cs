using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.Facility
{
    public class GroupFitnessLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public FitnessCenter Center { get; set; }

        public List<GroupFitnessClass> Classes { get; set; }
    }
}
