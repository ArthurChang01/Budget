using BudgetCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetCalculator
{
    public class BudgeProcessor
    {
        public BudgeProcessor(Period period, IEnumerable<Budget> ieBg)
        {
            this.Period = period;
            this.Budgets = ieBg;
        }

        public Period Period { get; }
        public IEnumerable<Budget> Budgets { get; }

        public int CalculateTheSameMonth()
        {
            return this.Period.DiffDays() * this.Budgets.FirstOrDefault()?.DayOfMonthMoney ?? 0;
        }

        public int CalculateDifferentMonth()
        {
            int sum = Budgets.Sum(o => o.Amount);

            if (this.Period.IsStartDateOnFirstday() == false)
            {
                Budget startBg = Budgets.FirstOrDefault(o => o.Month.Equals(this.Period.StartDate.Month));
                if (startBg != null)
                    sum -= this.Period.StartDate.Day * startBg.DayOfMonthMoney;
            }

            if (this.Period.IsEndDateOnLastday() == false)
            {
                Budget endBg = Budgets.FirstOrDefault(o => o.Month.Equals(this.Period.EndDate.Month));
                if (endBg != null)
                    sum -= (DateTime.DaysInMonth(this.Period.EndDate.Year, this.Period.EndDate.Month) - this.Period.EndDate.Day - 1) * endBg.DayOfMonthMoney;
            }

            return sum;
        }
    }
}