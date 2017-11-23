using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
{
    internal interface ISupportEngineersFilterChain
    {
        IEnumerable<SupportEngineer> Filter(IEnumerable<SupportEngineer> supportEngineersToFilter);
        ISupportEngineersFilterChain Successor { get; }
    }
}