using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncFitness.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace AsyncFitness.Web.Areas.Identity.Data;

public class AsyncFitnessUser : IdentityUser
{   
    public Customer ConvertToCustomer()
    {
        Customer customer = new Customer()
        {
            Email = this.Email,
            PasswordHash = this.PasswordHash,
            Phone = this.PhoneNumber
        };

        return customer;
    }

    public Trainer ConvertToTrainer()
    {
        Trainer trainer = new Trainer()
        {
            Email = this.Email,
            PasswordHash = this.PasswordHash,
            Phone = this.PhoneNumber
        };

        return trainer;
    }
}