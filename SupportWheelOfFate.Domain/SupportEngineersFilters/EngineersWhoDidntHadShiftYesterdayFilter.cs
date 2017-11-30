using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal class EngineersWhoDidntHadShiftYesterdayFilter : SupportEngineerFilterChain
    {
        private ISupportEngineersFilterChain _supportEngineersFilter;

        public EngineersWhoDidntHadShiftYesterdayFilter() : base(null)
        {
        }

        public EngineersWhoDidntHadShiftYesterdayFilter(ISupportEngineersFilterChain supportEngineersFilter) : base(supportEngineersFilter)
        {
        }

        protected override IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineersToFilter)
        {
            return supportEngineersToFilter.Where(se => se.DidntHadShiftYesterday());
        }
    }
}