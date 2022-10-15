using AsyncFitness.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models
{
    public abstract class User
    {
        [Key, Required, RegularExpression(@"^(\S+)@(\S+)\.\S+$"), MaxLength(100)]
        public string Email { get; set; }

        [Required, RegularExpression(@"^(\d){8}$"), MaxLength(8)]
        public string Phone { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string StreetName { get; set; }

        [Required, MaxLength(4)]
        public string StreetNumber { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, MaxLength(7)]
        public string PostalCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public byte[]? ProfileImage { get; set; }

        public bool ValidatePassword(string pw)
        {
            return pw == PasswordHash;
        }
    }
}
