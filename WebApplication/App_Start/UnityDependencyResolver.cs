using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace WebApplication.App_Start
{
    public class UnityDependencyResolver : UnityDependencyScope, IDependencyResolver
    {

        public UnityDependencyResolver(IUnityContainer container) : base(container)
        {

        }

        public IDependencyScope BeginScope()
        {
            return new UnityDependencyScope(Container.CreateChildContainer());
        }

    }
}