using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Unity;

namespace WebApplication.App_Start
{
    public class UnityHttpControllerActivator : IHttpControllerActivator

    {

        private IUnityContainer Container { get; set; }

        public UnityHttpControllerActivator(IUnityContainer container)
        {
            Container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {

            var scope = request.GetDependencyScope();

            return scope.GetService(controllerType) as IHttpController;

        }

    }
}