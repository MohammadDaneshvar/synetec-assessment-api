using AutoFixture;
using AutoMapper;
using NUnit.Framework;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Service.AutoMappers;
using SynetecAssessmentApi.Service.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynetecAssessmentApi.UnitTest
{
    [TestFixture]
    public class DomainMappingProfileTest
    {
        private IMapper _mapper;
        private readonly Fixture _fixture = new Fixture();
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
        }

        [Test]
        public void Mapping_Employee_To_EmployeeDto_Successfully()
        {
            var employee = _fixture.Create<Employee>();

            var employeeDto= _mapper.Map<EmployeeDto>(employee);

            Assert.AreEqual(employee.Fullname, employeeDto.Fullname);
            Assert.AreEqual(employee.JobTitle, employeeDto.JobTitle);
            Assert.AreEqual(employee.Salary, employeeDto.Salary);
            Assert.AreEqual(employee.Department.Description, employeeDto.Department.Description);
            Assert.AreEqual(employee.Department.Title, employeeDto.Department.Title);
        }
    }
}
