using SynetecAssessmentApi.Services;
using System;

namespace SynetecAssessmentApi.Services.Queries.Employees
{
    public class EmployeeBonusFormula : IEmployeeBonusFormula
    {
        public decimal Calculate(decimal employeSalary, decimal totalSalary,decimal bonusPoolAmount)
        {
            decimal  bonusAllocation=0;
            if (employeSalary > 0 && totalSalary > 0 && bonusPoolAmount > 0)
            {
                decimal bonusPercentage = employeSalary / totalSalary;
                bonusAllocation = bonusPercentage * bonusPoolAmount;
                bonusAllocation = Math.Round(bonusAllocation, 2);
            }
            return bonusAllocation;
        }

    }
}
