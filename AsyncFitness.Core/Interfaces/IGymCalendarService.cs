using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IGymCalendarService
    {
        GymCalendarWeekDto LoadCalendarWeek(DateTime date, Customer customer);
    }
}
