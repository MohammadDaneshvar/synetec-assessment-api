using AutoMapper;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Service.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SynetecAssessmentApi.Service.AutoMappers
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<Employee, EmployeeDto>();
            
            
        }
    }
}
