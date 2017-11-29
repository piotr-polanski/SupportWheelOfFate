using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Infrastructure;
using SupportWheelOfFate.Domain.Repository;
using Unity;
using Unity.Lifetime;

namespace SupportWheelOfFate.Domain.IoC
{
    public class WheelOfFateUnityRegistration
    {
        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<ISupportEngineersRepository, SupportEngineersRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ISupportEngineerFilterChainFactory, DefaultSupportEngineerFilterChainFactory>();
            unityContainer.RegisterType<IWheelOfFate, WheelOfFate>();
            unityContainer.RegisterType<ICalendar, Calendar>();
            unityContainer.RegisterType<ISupportEngineersFactory, SupportEngineersFactory>();
        }
    }
}
