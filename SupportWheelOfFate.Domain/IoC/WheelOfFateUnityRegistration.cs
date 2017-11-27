using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Repository;
using Unity;

namespace SupportWheelOfFate.Domain.IoC
{
    public class WheelOfFateUnityRegistration
    {
        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<ISupportEngineersRepository, SupportEngineersRepository>();
            unityContainer.RegisterType<IFilterChainFactory, DefaultFilterChainFactory>();
            unityContainer.RegisterType<IWheelOfFate, WheelOfFate>();
        }
    }
}
