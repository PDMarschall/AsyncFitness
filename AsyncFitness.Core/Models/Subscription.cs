using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }= String.Empty;        
        public string Description { get; set; }= String.Empty;
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; } = decimal.Zero;
        public bool GroupFitness { get; set; } = false;
    }
}