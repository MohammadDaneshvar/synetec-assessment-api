using AutoFixture;
using NUnit.Framework;
using SynetecAssessmentApi.Service.Contracts.Queries;
using SynetecAssessmentApi.Service.Contracts.Queries.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynetecAssessmentApi.UnitTest
{
    [TestFixture]
    public class GetEmplyeeBonusQueryValidationTest
    {
        private GetEmplyeeBonusQueryValidation _getEmplyeeBonusQueryValidation=new GetEmplyeeBonusQueryValidation();

        private readonly Fixture _fixture = new Fixture();
        [SetUp]
        public  void Setup()
        {
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
              .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
        [Test]
        public void GetEmplyeeBonusQueryValidation_ShouldReturnFlase_WhenSelectedEmployeeId_IsNull()
        {
            var model = _fixture.Build<GetEmplyeeBonusQuery>().With(x=>x.selectedEmployeeId,()=>null).Create();
            var result= _getEmplyeeBonusQueryValidation.Validate(model);
            Assert.IsTrue(result.Errors.Select(x=>x.ErrorMessage).Contains(@"'selected Employee Id' must not be empty."));
            Assert.IsFalse(result.IsValid);
        }
    }
}
