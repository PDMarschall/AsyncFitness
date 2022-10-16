using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AsyncFitness.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace AsyncFitness.Web.Areas.Identity.Data;

public class AsyncFitnessUser : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public Customer ConvertToCustomer()
    {
        Customer customer = new Customer()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,            
            Phone = this.PhoneNumber
        };

        return customer;
    }

    public Trainer ConvertToTrainer()
    {
        Trainer trainer = new Trainer()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,            
            Phone = this.PhoneNumber
        };

        return trainer;
    }
}