using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace WebApplication.App_Start
{
    public class UnityDependencyScope : IDependencyScope
    {

        protected IUnityContainer Container { get; set; }


        public UnityDependencyScope(IUnityContainer container)
        {
            Container = container;

        }

        public void Dispose()
        {

            Container.Dispose();

        }

        public object GetService(Type serviceType)
        {
            return Container.IsRegistered(serviceType)

                        ? Container.Resolve(serviceType)

                        : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {

            return Container.ResolveAll(serviceType);

        }

    }

}