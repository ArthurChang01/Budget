using BudgetCalculator.Entities;
using System;
using System.Collections.Generic;

namespace BudgetCalculator
{
    public class BudgetRetriver
    {
        private IBudgetRepository _respository;
        private BudgeProcessor _processor;

        public BudgetRetriver(IBudgetRepository respository)
        {
            _respository = respository;
        }

        public int CalculateBudget(DateTime startDate, DateTime endDate)
        {
            Period period = new Period(startDate, endDate);
            period.IsInvalid();

            IEnumerable<Budget> ieBg = this._respository.GetBudgets(new[] {
                new BudgetSearcher(startDate.Year, startDate.Month),
                new BudgetSearcher(endDate.Year, endDate.Month)
            });

            BudgeProcessor processor = new BudgeProcessor(period, ieBg);

            return period.IsTheSameMonth()
                ? processor.CalculateTheSameMonth()
                : processor.CalculateDifferentMonth();
        }
    }
}