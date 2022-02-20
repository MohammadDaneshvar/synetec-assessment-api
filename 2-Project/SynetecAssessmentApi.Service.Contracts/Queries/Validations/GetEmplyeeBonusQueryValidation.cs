using FluentValidation;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SynetecAssessmentApi.Service.Contracts.Queries.Validations
{
    public class GetEmplyeeBonusQueryValidation : AbstractValidator<GetEmplyeeBonusQuery>, ICommandValidator<GetEmplyeeBonusQuery>
    {
        public GetEmplyeeBonusQueryValidation()
        {
            RuleFor(x => x.selectedEmployeeId).NotNull();
        }
    }
}
