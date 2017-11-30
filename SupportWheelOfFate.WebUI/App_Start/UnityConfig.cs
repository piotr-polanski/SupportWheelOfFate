using System.Web.Mvc;
using SupportWheelOfFate.Domain.Infrastructure.IoC;
using Unity;
using Unity.Mvc5;

namespace SupportWhellOfFate.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            WheelOfFateUnityRegistration.RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}