using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace MyVehicleRepairServiceNeeds.TowApp.Web.App_Start
{
    internal class UnityDependencyResolver : IDependencyResolver
    {
        private UnityContainer container;

        public UnityDependencyResolver(UnityContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}