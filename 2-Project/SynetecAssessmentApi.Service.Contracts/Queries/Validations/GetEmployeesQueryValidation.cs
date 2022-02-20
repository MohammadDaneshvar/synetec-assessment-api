using FluentValidation;
using Framework.Application;
using SynetecAssessmentApi.Service.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SynetecAssessmentApi.Service.Contracts.Queries.Validations
{
    public class GetEmployeesQueryValidation : AbstractValidator<GetEmployeesQuery>, ICommandValidator<GetEmployeesQuery>
    {
        public GetEmployeesQueryValidation()
        {
        }
    }
}
