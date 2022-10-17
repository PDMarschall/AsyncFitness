using AsyncFitness.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.User
{
    public class Subscription
    {
        [Key, Required]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public decimal Cost { get; set; } = decimal.Zero;

        public bool IsGroupFitness { get; set; } = false;

        public List<Customer> Subscribers { get; set; } = new List<Customer>();

        public override string ToString()
        {
            return Name;
        }
    }
}