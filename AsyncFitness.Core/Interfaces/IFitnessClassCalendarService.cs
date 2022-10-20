using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IFitnessClassCalendarService
    {
        FitnessCenter FitnessCenter { get; }
        Task<List<GroupFitnessClassCalendar>> GetCalendarAsync(int year);
        Task<List<GroupFitnessClassCalendar>> GetCalendarAsync(int year, int month);        
        Task<GroupFitnessClassCalendar> GetCalendarAsync(int year, int month, int week);
        Task<GroupFitnessClassCalendar> GetCalendarAsync(DateTime date);
    }
}
