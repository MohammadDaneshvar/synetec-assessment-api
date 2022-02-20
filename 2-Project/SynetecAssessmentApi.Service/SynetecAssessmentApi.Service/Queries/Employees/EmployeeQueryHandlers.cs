using AutoMapper;
using Framework.Application;
using Framework.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Service.Contracts.Dtos;
using SynetecAssessmentApi.Service.Contracts.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace  SynetecAssessmentApi.Services.Queries.Employees
{
    public class EmployeeQueryHandlers : ICommandHandler<GetEmplyeeBonusQuery>, ICommandHandler<GetEmployeesQuery>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeBonusFormula _employeeBonusFormula;

        public EmployeeQueryHandlers(IRepository<Employee> employeeRepository, IMapper mapper, IEmployeeBonusFormula employeeBonusFormula)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeBonusFormula = employeeBonusFormula ?? throw new ArgumentNullException(nameof(employeeBonusFormula));
        }
        public async Task HandleAsync(GetEmplyeeBonusQuery command, CancellationToken cancellationToken)
        {
            //load the details of the selected employee using the Id
            Employee employee = await _employeeRepository.Query()
                .Include(x=>x.Department)
                .SingleOrDefaultAsync(item => item.Id == command.selectedEmployeeId, cancellationToken);
            
            //throw an exception if an employee does not exist
            if (employee == null)
            {
                throw new ExceptionResult("SelectedEmployeeId is not exists in the database.");
            }

            //get the total salary budget for the company
            var totalSalary = await _employeeRepository.Query().SumAsync(item => item.Salary, cancellationToken);

            //calculate the bonus allocation for the employee
            decimal bonusAllocation = _employeeBonusFormula.Calculate(employee.Salary, totalSalary, command.bonusPoolAmount);
            
            var result = _mapper.Map<EmployeeDto>(employee);
            command.Result = new BonusPoolCalculatorResultDto
            {
                Employee = result,
                Amount = bonusAllocation
            };
        }

        public async Task HandleAsync(GetEmployeesQuery command, CancellationToken cancellationToken)
        {
            var result = new List<EmployeeDto>();

            var employees = await _employeeRepository.Query()
                 .Include(e => e.Department)
                 .ToListAsync(cancellationToken);

            if (employees != null)
                result = _mapper.Map<List<EmployeeDto>>(employees);

            command.Result = result;
        }
    }
}
