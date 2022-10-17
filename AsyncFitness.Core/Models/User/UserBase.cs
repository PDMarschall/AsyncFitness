using AsyncFitness.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Models.User
{
    public abstract class UserBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, RegularExpression(@"^(\S+)@(\S+)\.\S+$"), MaxLength(100)]
        public string Email { get; set; }

        [Required, RegularExpression(@"^(\d){8}$"), MaxLength(8)]
        public string Phone { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string StreetName { get; set; } = string.Empty;

        [Required, MaxLength(4)]
        public string StreetNumber { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required, MaxLength(7)]
        public string PostalCode { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public byte[]? ProfileImage { get; set; }
    }
}
