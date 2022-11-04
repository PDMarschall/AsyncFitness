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
            int weekOfYear = ISOWeek.GetWeekOfYear(DateTime.Now);
            DateTime[] weekDates = new DateTime[2];
            weekDates[0] = ISOWeek.ToDateTime(DateTime.Now.Year, weekOfYear, DayOfWeek.Monday);
            weekDates[1] = ISOWeek.ToDateTime(DateTime.Now.Year, weekOfYear, DayOfWeek.Sunday);

            return weekDates;
        }
    }
}
