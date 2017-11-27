using System.Web.Mvc;
using SupportWheelOfFate.Domain.IoC;
using Unity;
using Unity.Mvc5;

namespace SupportWhellOfFate.Web
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