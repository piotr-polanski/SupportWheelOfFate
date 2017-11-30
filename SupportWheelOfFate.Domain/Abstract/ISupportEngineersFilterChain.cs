using System.Collections.Generic;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ISupportEngineersFilterChain
    {
        IEnumerable<ISupportEngineer> Filter(IEnumerable<ISupportEngineer> supportEngineersToFilter);
        ISupportEngineersFilterChain Successor { get; }
    }
}