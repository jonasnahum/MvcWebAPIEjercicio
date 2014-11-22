using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using System.Web.Mvc;
using Castle.MicroKernel;
using MvcWebAPIEjercicio.DependencyInjection.Installers;
using MvcWebAPIEjercicio.Controllers;
using System.Linq;
using System.Collections.Generic;
using Castle.Core;

namespace WindsorContainerTests
{
    namespace WindsorUnitTest
    {
        [TestClass]
        public class ControllersInstallerTests
        {
            private IWindsorContainer containerWithControllers;

            public ControllersInstallerTests()
            {                
                containerWithControllers = new WindsorContainer()
                            .Install(new ControllersInstaller());
            }

            [TestInitialize]
            public void All_controllers_implement_IController()
            {
                var allHandlers = GetAllHandlers(containerWithControllers);
                var controllerHandlers = GetHandlersFor(typeof(IController), containerWithControllers);

                Assert.IsNotNull(allHandlers);                
                Assert.AreEqual(allHandlers, controllerHandlers);
            }
            private IHandler[] GetAllHandlers(IWindsorContainer container)
            {
                return GetHandlersFor(typeof(object), container);
            }

            private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
            {
                return container.Kernel.GetAssignableHandlers(type);
            }

            [TestMethod]
            public void All_controllers_are_registered()
            {
                // Is<TType> is an helper, extension method from Windsor in the Castle.Core.Internal namespace
                // which behaves like 'is' keyword in C# but at a Type, not instance level
                var allControllers = GetPublicClassesFromApplicationAssembly(c => c is IController );
                var registeredControllers = GetImplementationTypesFor(typeof(IController), containerWithControllers);
                Assert.AreEqual(allControllers, registeredControllers);
            }
            private Type[] GetImplementationTypesFor(Type type, IWindsorContainer container)
            {
                return GetHandlersFor(type, container)
                    .Select(h => h.ComponentModel.Implementation)
                    .OrderBy(t => t.Name)
                    .ToArray();
            }

            private Type[] GetPublicClassesFromApplicationAssembly(Predicate<Type> where)
            {
                return typeof(HomeController).Assembly.GetExportedTypes()
                    .Where(t => t.IsClass)
                    .Where(t => t.IsAbstract == false)
                    .Where(where.Invoke)
                    .OrderBy(t => t.Name)
                    .ToArray();
            }

            [TestMethod]
            public void All_controllers_are_transient()
            {
                var nonTransientControllers = GetHandlersFor(typeof(IController), containerWithControllers)
                    .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.Transient)
                    .ToArray();

                Assert.IsNull(nonTransientControllers);
            }

            [TestMethod]
            public void All_controllers_expose_themselves_as_service()
            {
                var controllersWithWrongName = GetHandlersFor(typeof(IController), containerWithControllers)
                    .Where(controller => controller.ComponentModel.Services.Single() != controller.ComponentModel.Implementation)
                    .ToArray();

                Assert.IsNull(controllersWithWrongName);
            }
        }
    }

}
