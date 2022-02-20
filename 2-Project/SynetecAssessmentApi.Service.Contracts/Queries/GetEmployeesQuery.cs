using Framework.Application;
using SynetecAssessmentApi.Service.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SynetecAssessmentApi.Service.Contracts.Queries
{
    public class GetEmployeesQuery : IHaveResult<IEnumerable<EmployeeDto>>, IRestrictedCommand
    {
        public IEnumerable<EmployeeDto> Result { get; set; }
    }
}
