using System.Collections.Generic;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal abstract class SupportEngineerFilterChain : ISupportEngineersFilterChain
    {
        protected SupportEngineerFilterChain(ISupportEngineersFilterChain successor)
        {
            Successor = successor;
        }
        public ISupportEngineersFilterChain Successor { get; }

        public IEnumerable<SupportEngineer> Filter(IEnumerable<SupportEngineer> supportEngineersToFilter)
        {
            var filteredEngineers = FilterEngineers(supportEngineersToFilter);

            return Successor == null ? filteredEngineers : Successor.Filter(filteredEngineers);
        }
        protected abstract IEnumerable<SupportEngineer> FilterEngineers(IEnumerable<SupportEngineer> supportEngineers);
    }
}