using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.FilterChainFactories
{
    public interface ISupportEngineerFilterChainFactory
    {
        ISupportEngineersFilterChain Create();
    }
}