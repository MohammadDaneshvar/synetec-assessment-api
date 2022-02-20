using AutoFixture;
using AutoMapper;
using Framework.Application;
using Framework.Domain.Repository;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Service.AutoMappers;
using SynetecAssessmentApi.Service.Contracts.Queries;
using SynetecAssessmentApi.Services.Queries.Employees;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.UnitTest
{
    [TestFixture]
    public class EmployeeQueryHandlersTest
    {
        private readonly Fixture _fixture = new Fixture();
        private EmployeeQueryHandlers _employeeQueryHandlers;
        private Mock<IRepository<Employee>> _employeeRepositoryMock;
        private IMapper _mapper;
        private Mock<IEmployeeBonusFormula> _employeeBonusFormula;
        [SetUp]
        public void Setup()
        {
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainMappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();

            _employeeRepositoryMock = new Mock<IRepository<Employee>>();
            _employeeBonusFormula = new Mock<IEmployeeBonusFormula>();
        }

        [Test]
        public void GetEmplyeeBonusQuery_Should_ThrowException_When_EmployIdIsNotExists()
        {
            var getEmplyeeBonusQuery = _fixture.Build<GetEmplyeeBonusQuery>().With(x => x.selectedEmployeeId, 1).Create();
            var employees = new List<Employee>{
                _fixture.Build<Employee>().With(x=>x.Id,2).Create()
           };

            _employeeRepositoryMock.Setup(x => x.Query()).Returns(employees.AsQueryable().BuildMock().Object);

            _employeeQueryHandlers = new EmployeeQueryHandlers(_employeeRepositoryMock.Object, _mapper, _employeeBonusFormula.Object);

            var exception = Assert.ThrowsAsync<ExceptionResult>(() => _employeeQueryHandlers.HandleAsync(getEmplyeeBonusQuery, CancellationToken.None));
            Assert.AreEqual(exception.Message, "SelectedEmployeeId is not exists in the database.");
            _employeeRepositoryMock.Verify(x => x.Query());
        }

        [Test]
        [TestCase(100000)]
        [TestCase(500000)]
        [TestCase(800000)]
        public async Task GetEmplyeeBonusQuery_ReturnsProperValue(decimal expectedBonusAllocation)
        {
            var selectedEmployeeId = 1;

            var getEmplyeeBonusQuery = _fixture.Build<GetEmplyeeBonusQuery>().With(x => x.selectedEmployeeId, selectedEmployeeId).Create();
            var employees = new List<Employee>{
                _fixture.Build<Employee>().With(x=>x.Id,selectedEmployeeId).Create()
           };

            _employeeRepositoryMock.Setup(x => x.Query()).Returns(employees.AsQueryable().BuildMock().Object);
            _employeeBonusFormula.Setup(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(expectedBonusAllocation);

            _employeeQueryHandlers = new EmployeeQueryHandlers(_employeeRepositoryMock.Object, _mapper, _employeeBonusFormula.Object);
            await _employeeQueryHandlers.HandleAsync(getEmplyeeBonusQuery, CancellationToken.None);
            var result = getEmplyeeBonusQuery.Result;

            _employeeRepositoryMock.Verify(x => x.Query());
            _employeeBonusFormula.Verify(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()));
            Assert.AreEqual(result.Amount, expectedBonusAllocation);
        }

        [Test]
        public async Task GetEmployeesQuery_ShouldReturnTwoRecord_WhenNumberOfEmployeesAreTwo()
        {
            var command = _fixture.Create<GetEmployeesQuery>();
            var employees = _fixture.CreateMany<Employee>(2);

            _employeeRepositoryMock.Setup(x => x.Query()).Returns(employees.AsQueryable().BuildMock().Object);

            _employeeQueryHandlers = new EmployeeQueryHandlers(_employeeRepositoryMock.Object, _mapper, _employeeBonusFormula.Object);
            await _employeeQueryHandlers.HandleAsync(command, CancellationToken.None);

            Assert.AreEqual(command.Result.Count(),2);
        }
    }
}
