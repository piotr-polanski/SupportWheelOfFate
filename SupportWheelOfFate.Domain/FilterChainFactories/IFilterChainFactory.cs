using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.FilterChainFactories
{
    internal interface IFilterChainFactory
    {
        ISupportEngineersFilterChain Create();
    }
}