using Castle.Windsor;
using Castle.Windsor.Installer;
using MvcWebAPIEjercicio.Windsor.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcWebAPIEjercicio
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();
        }
        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            //create container
            container = new WindsorContainer();

            //register installers
            container.Install(FromAssembly.This());

            //create controllers factory
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            //create web api controllers factory
            var webApicontrollerFactory = new WindsorWebApiControllerFactory(container);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), webApicontrollerFactory);
        }
        protected void Application_End()
        {
            container.Dispose();
        }
    }
}