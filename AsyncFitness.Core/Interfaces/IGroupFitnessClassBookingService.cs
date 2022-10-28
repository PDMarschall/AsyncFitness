using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IGroupFitnessClassBookingService
    {        
        List<GroupFitnessClass> LoadClassesAsync(Customer customer);
        //Task<List<GroupFitnessClass>> LoadClassesAsync(Customer customer);
        List<GroupFitnessClass> LoadClassesAsync(Trainer trainer);
        //Task<List<GroupFitnessClass>> LoadClassesAsync(Trainer trainer);
        Task<List<GroupFitnessClass>> FilterClassesAsync(Dictionary<string, string> criteria);
        Task SaveClassesAsync();
    }
}