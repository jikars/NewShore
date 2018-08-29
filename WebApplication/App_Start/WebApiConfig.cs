using BussinesLogic.Implementation;
using BussinesLogic.Interfaces;
using DataAccess.DataAccess;
using DataAccess.Interfaces;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Unity;
using Unity.Lifetime;
using Utilities.Implementation.FileManagement;
using Utilities.Interface;
using WebApplication.App_Start;
using WebApplication.Controllers;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IClientNewshoreService, ClientNewshoreService>();
            container.RegisterType<IClientDao, ClientDao>();
            container.RegisterType<ILetterDao, LetterDao>();
            container.RegisterType<IClientNewshore, ClientNewshore>();
            container.RegisterType<ILetters, Letters>();
            container.RegisterType<IFileManager, FileManager>();
            container.RegisterInstance<IHttpControllerActivator>(new UnityHttpControllerActivator(container));
           
            foreach (var type in Assembly.GetExecutingAssembly().GetExportedTypes().
                           Where(x => x.GetInterface(typeof(IHttpController).Name) != null))
            {
                container.RegisterType(type);
            }

            config.DependencyResolver = new UnityDependencyResolver(container);
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
