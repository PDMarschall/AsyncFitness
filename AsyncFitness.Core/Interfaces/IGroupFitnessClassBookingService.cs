using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IGroupFitnessClassBookingService
    {
        Task LoadClasses();
        Task FilterClasses(Dictionary<string, string> criteria);
        Task SaveClasses();
    }
}
