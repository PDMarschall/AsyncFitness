using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime[] GetWeekStartAndEnd(this DateTime date)
        {
            DateTime[] weekStartAndEnd = new DateTime[] 
            { 
                ISOWeek.ToDateTime(year:DateTime.Now.Year, week:ISOWeek.GetWeekOfYear(DateTime.Now), dayOfWeek:DayOfWeek.Monday), 
                ISOWeek.ToDateTime(year:DateTime.Now.Year, week:ISOWeek.GetWeekOfYear(DateTime.Now), dayOfWeek:DayOfWeek.Sunday).AddHours(23).AddMinutes(59).AddSeconds(59) 
            };
            return weekStartAndEnd;
        }
    }
}
