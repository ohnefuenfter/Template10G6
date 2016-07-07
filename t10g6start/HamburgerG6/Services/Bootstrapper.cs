using HamburgerG6.Services.SDM;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerG6.Services
{
    public static class ServiceManager
    {
        public static IUnityContainer Container { get; set; }

        public static T Resolve<T>() where T : class
        {
            if (Container == null) return null;
            return Container.Resolve<T>();
        }
    }

    public class Bootstrapper
    {
        public static IUnityContainer StartServices()
        {
            var container = new UnityContainer();
            container.RegisterType<ISDMService, DisconnectedSDMService>();
            ServiceManager.Container = container;
            return container;
        }
    }
}
