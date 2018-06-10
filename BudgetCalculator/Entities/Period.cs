using System;

namespace BudgetCalculator.Entities
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public void IsInvalid()
        {
            if (this.StartDate > this.EndDate)
                throw new ArgumentException();
        }

        public bool IsTheSameMonth()
        {
            return this.StartDate.Month == this.EndDate.Month;
        }

        public bool IsStartDateOnFirstday()
        {
            return this.StartDate.Day == 1;
        }

        public bool IsEndDateOnLastday()
        {
            return this.EndDate.Day == DateTime.DaysInMonth(this.EndDate.Year, this.EndDate.Month);
        }

        public int DiffDays()
        {
            return EndDate.AddDays(1).Subtract(StartDate).Days;
        }

    }
}
