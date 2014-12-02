using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebAPIEjercicio.Windsor.Installers
{
    public class AlumnosAppInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(Configuration.FromAppConfig());
        }
    }
}