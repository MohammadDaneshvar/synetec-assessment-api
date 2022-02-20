using Framework.Application.Config;
using Framework.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SynetecAssessmentApi.Extensions;
using SynetecAssessmentApi.Persistence;
using SynetecAssessmentApi.Service.Config;
using SynetecAssessmentApi.Service.Contracts.Queries;
using SynetecAssessmentApi.Services;
using SynetecAssessmentApi.Services.Queries.Employees;

namespace SynetecAssessmentApi
{
    public class Startup
    {
        private Container _container;
        public Startup(IConfiguration configuration)
        {
            _container = new Container();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore()
                .AddControllerActivation();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SynetecAssessmentApi", Version = "v1" });
            });
            
            services.AddScoped<IDbContext, AppDbContext>(x => 
            new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "HrDb").Options));
            services.AddDbContext<AppDbContext>(options=>options.UseInMemoryDatabase(databaseName: "HrDb"));

            services.AddAutoMapper();
            services.AddDistributedMemoryCache();

            FrameworkConfigurator.WireUp(_container, false, typeof(EmployeeQueryHandlers).Assembly, typeof(GetEmployeesQuery).Assembly);
            AppServiceConfigurator.WireUp(_container, typeof(EmployeeQueryHandlers).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(_container);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SynetecAssessmentApi v1"));
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
