using Framework.Application;
using Framework.Data.EF;
using Framework.Domain.Repository;
using SimpleInjector;
using SynetecAssessmentApi.Services.Queries.Employees;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SynetecAssessmentApi.Service.Config
{
    public class AppServiceConfigurator
    {
        public class EventHandlerFactory : IEventHandlerFactory
        {
            private readonly Container _container;

            public EventHandlerFactory(Container container)
            {
                _container = container;
            }
            public List<IEventHandler<T>> CreateHandler<T>()
            {
                return _container.GetAllInstances<IEventHandler<T>>().ToList();
            }
        }
        public static void WireUp(Container container, Assembly serviceAssembly )
        {
            container.Register<IUnitOfWork, EFUnitOfWork>();
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(LogDecoratorCommandHandler<>));
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidatorCommandHandler<>));
            container.Register<IKeyGenerator, KeyGenerator>();
            container.Register(typeof(IRepository<>), typeof(EFRepository<>));
            container.Collection.Register(typeof(ICommandHandler<>),new List<Assembly> { serviceAssembly });
            container.Register<IEmployeeBonusFormula, EmployeeBonusFormula>();
        }
    }
}
