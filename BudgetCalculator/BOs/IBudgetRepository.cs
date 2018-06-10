using BudgetCalculator.Entities;
using System.Collections.Generic;

namespace BudgetCalculator
{
    public interface IBudgetRepository
    {
        IEnumerable<Budget> GetBudgets(IEnumerable<BudgetSearcher> searchers);
    }
}