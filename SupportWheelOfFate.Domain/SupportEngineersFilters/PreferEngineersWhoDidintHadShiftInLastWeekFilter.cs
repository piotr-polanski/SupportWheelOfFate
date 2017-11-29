using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal class PreferEngineersWhoDidintHadShiftInLastWeekFilter : SupportEngineerFilterChain
    {
        public PreferEngineersWhoDidintHadShiftInLastWeekFilter(ISupportEngineersFilterChain successor) : base(successor)
        {
        }

        public PreferEngineersWhoDidintHadShiftInLastWeekFilter() : base(null)
        {
        }

        protected override IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineers)
        {
            var engineersWhoDidntHadShiftInLastFiveDays =
                supportEngineers.Where(se => se.DidntHadShiftInLastWeek());
            if (engineersWhoDidntHadShiftInLastFiveDays.Count() > 1)
            {
                return engineersWhoDidntHadShiftInLastFiveDays;
            }

            return supportEngineers;
        }
    }
}