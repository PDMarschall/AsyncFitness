using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    public class GroupFitnessClassCalendar
    {
        private List<GroupFitnessClass>[] _calendarContainer;

        public FitnessCenter Center { get; private set; }

        public GroupFitnessClassCalendar(FitnessCenter fitnessCenter)
        {
            Center = fitnessCenter;
            _calendarContainer = new List<GroupFitnessClass>[7];
        }

        public void AddClass(GroupFitnessClass fitnessClass)
        {
            GuardAgainstNull(fitnessClass);
            InsertClassAfterPriorClass(fitnessClass);
        }

        public void AddClassRange(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
            GuardAgainstNullCollection(fitnessClasses);
            foreach (GroupFitnessClass fitnessClass in fitnessClasses)
            {
                InsertClassAfterPriorClass(fitnessClass);
            }
        }



        private void GuardAgainstNullCollection(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
            if (fitnessClasses == null)
            {
                throw new NullReferenceException("GroupFitnessClass-collection cannot be null");
            }
            foreach (GroupFitnessClass fitnessClass in fitnessClasses)
            {
                GuardAgainstNull(fitnessClass);
            }
        }

        private void GuardAgainstNull(GroupFitnessClass fitnessClass)
        {
            if (fitnessClass == null)
            {
                throw new NullReferenceException("GroupFitnessClass cannot be null.");
            }
            if (!fitnessClass.IsValid())
            {
                throw new ArgumentException("GroupFitnessClass.Start cannot be later than GroupFitnessClass.End");
            }
        }

        private void InsertClassAfterPriorClass(GroupFitnessClass fitnessClass)
        {
            int indexOfClass = (int)fitnessClass.Start.DayOfWeek;
            int indexToInsertClass = _calendarContainer[indexOfClass]
                .IndexOf(_calendarContainer[indexOfClass]
                .First(c => c.End < fitnessClass.Start));
            _calendarContainer[indexOfClass].Insert(indexToInsertClass, fitnessClass);
        }
    }
}
