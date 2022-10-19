using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    public class GroupFitnessClassCalendar : IEnumerable<GroupFitnessClass>
    {
        private List<GroupFitnessClass>[] _calendarContainer;

        public FitnessCenter Center { get; private set; }

        public GroupFitnessClassCalendar(FitnessCenter fitnessCenter)
        {
            Center = fitnessCenter;
            _calendarContainer = new List<GroupFitnessClass>[7];
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i] = new List<GroupFitnessClass>();
            }
        }

        public void AddClass(GroupFitnessClass fitnessClass)
        {
            GuardAgainstNull(fitnessClass);
            GuardAgainstInvalid(fitnessClass);
            InsertClassAfterPriorClass(fitnessClass);
        }

        public void AddClassRange(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
            GuardAgainstNullCollection(fitnessClasses);
            GuardAgainstInvalidCollection(fitnessClasses);
            foreach (GroupFitnessClass fitnessClass in fitnessClasses)
            {
                InsertClassAfterPriorClass(fitnessClass);
            }
        }



        public List<string> GetDoubleBookings()
        {
            List<string> errorLog = new List<string>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                for (int y = 1; y == _calendarContainer[i].Count; y++)
                {

                }
            }

            return errorLog;
        }

        private void InsertClassAfterPriorClass(GroupFitnessClass fitnessClass)
        {
            int indexOfClass = (int)fitnessClass.Start.DayOfWeek;
            int indexToInsertClass = _calendarContainer[indexOfClass]
                .IndexOf(_calendarContainer[indexOfClass]
                .FirstOrDefault(c => c.End >= fitnessClass.Start));

            if (indexToInsertClass != -1)
            {
                _calendarContainer[indexOfClass].Insert(indexToInsertClass, fitnessClass);
            }
            else
            {
                _calendarContainer[indexOfClass].Add(fitnessClass);
            }
        }

        #region GuardMethods
        private void GuardAgainstNullCollection(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
            if (fitnessClasses == null)
            {
                throw new NullReferenceException("GroupFitnessClass-collection cannot be null");
            }

        }

        private void GuardAgainstInvalidCollection(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
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
        }

        private void GuardAgainstInvalid(GroupFitnessClass fitnessClass)
        {
            if (!fitnessClass.IsValid())
            {
                throw new ArgumentException($"GroupFitnessClass ID:{fitnessClass.Id} did not pass internal class validity test.");
            }
        }
        #endregion

        #region Enumerator
        public IEnumerator<GroupFitnessClass> GetEnumerator()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                foreach (GroupFitnessClass fitnessClass in _calendarContainer[i])
                {
                    yield return fitnessClass;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
