using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models
{
    public class GymCustomer
    {
        [Key, Required, RegularExpression(@"^(\d){8}$")]
        public string Phone { get; set; }
        [Required, RegularExpression(@"^(\S+)@(\S+)\.\S+$")]
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public Subscription? Subscription { get; set; }
    }
}
