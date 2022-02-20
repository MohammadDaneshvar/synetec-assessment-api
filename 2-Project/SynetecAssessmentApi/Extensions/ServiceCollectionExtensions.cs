using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Service.AutoMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainMappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }
    }
}
