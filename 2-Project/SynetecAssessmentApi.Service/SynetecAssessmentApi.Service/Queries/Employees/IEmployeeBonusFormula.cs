namespace SynetecAssessmentApi.Services.Queries.Employees
{
    public interface IEmployeeBonusFormula
    {
        public decimal Calculate(decimal employeSalary, decimal totalSalary, decimal bonusPoolAmount);
    }
}
