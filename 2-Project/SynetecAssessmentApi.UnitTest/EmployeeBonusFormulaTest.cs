using NUnit.Framework;
using SynetecAssessmentApi.Services.Queries.Employees;

namespace SynetecAssessmentApi.UnitTest
{
    [TestFixture]
    public class Tests
    {
        private EmployeeBonusFormula _bonusFormula;
        [SetUp]
        public void Setup()
        {
            _bonusFormula = new EmployeeBonusFormula();
        }

        [Test]
        [TestCase(3000, 1000000, 50000, 150)]
        [TestCase(3060, 1030000, 54000, 160.43)]
        [TestCase(3060, 1030000, 150000, 445.63)]
        [TestCase(5060, 1030000, 150000, 736.89)]
        [TestCase(-3060, 1030000, 54000, 0)]
        [TestCase(0, -2, 0, 0)]
        [TestCase(0, 0, -2, 0)]
        [TestCase(-1, 0, 0, 0)]
        [TestCase(0, 0, 0, 0)]
        public void Calculate_ReturnsProperValue(decimal employeSalary, decimal totalSalary, decimal bonusPoolAmount, decimal expectedResult)
        {
            var result = _bonusFormula.Calculate(employeSalary, totalSalary, bonusPoolAmount);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
