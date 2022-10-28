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
        Task<IEnumerable<GroupFitnessClass>> LoadClassesAsync(Customer customer);        
        Task<IEnumerable<GroupFitnessClass>> LoadClassesAsync(Trainer trainer);
        Task<IEnumerable<GroupFitnessClass>> FilterClassesAsync(Dictionary<string, string> criteria);
        Task SaveClassesAsync();
    }
}