using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.FilterChainFactories
{
    public interface IFilterChainFactory
    {
        ISupportEngineersFilterChain Create();
    }
}