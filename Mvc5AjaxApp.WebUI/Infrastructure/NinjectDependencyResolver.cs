using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Mvc5AjaxApp.Domain.Entities;
using Mvc5AjaxApp.Domain.Repository;
using Mvc5AjaxApp.WebUI.Infrastructure.Generator;
using Ninject;

namespace Mvc5AjaxApp.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<AppDbContext>().To<AppDbContext>();
            kernel.Bind<IDigitGenerator>().To<DigitGenerator>();
            kernel.Bind<HashSet<Digit>>().To<HashSet<Digit>>()
                .WithConstructorArgument("comparer", new DigitComparer());
            kernel.Bind<IDigitCreator>().To<DigitCreator>();
        }
    }
}