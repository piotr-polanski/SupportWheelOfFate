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

        private bool shouldBrakeChain;

        public ISupportEngineersFilterChain Successor { get; }

        public IEnumerable<ISupportEngineer> Filter(IEnumerable<ISupportEngineer> supportEngineersToFilter)
        {
            var filteredEngineers = FilterEngineers(supportEngineersToFilter);

            return Successor == null || shouldBrakeChain ? filteredEngineers : Successor.Filter(filteredEngineers);
        }

        protected void BrakeTheChain()
        {
            shouldBrakeChain = true;
        }
        protected abstract IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineers);

    }
}