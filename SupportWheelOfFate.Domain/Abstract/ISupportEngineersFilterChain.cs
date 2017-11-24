using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
{
    internal interface ISupportEngineersFilterChain
    {
        IEnumerable<ISupportEngineer> Filter(IEnumerable<ISupportEngineer> supportEngineersToFilter);
        ISupportEngineersFilterChain Successor { get; }
    }
}