using System.Collections.Generic;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal abstract class SupportEngineerFilterChain : ISupportEngineersFilterChain
    {
        private readonly ISupportEngineersFilterChain _successor;

        protected SupportEngineerFilterChain()
        {
            
        }
        protected SupportEngineerFilterChain(ISupportEngineersFilterChain successor)
        {
            _successor = successor;
        }

        public abstract IEnumerable<SupportEngineer> Filter(IEnumerable<SupportEngineer> supportEngineersToFilter);
    }
}