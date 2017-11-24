using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal class EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter : SupportEngineerFilterChain
    {
        public EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter() : base(null)
        {
        }

        public EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter(ISupportEngineersFilterChain successor) : base(successor)
        {
        }
        protected override IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineers)
        {
            return supportEngineers.Where(se => se.DidntHadTwoShiftInLastTwoWeeks()).ToList();
        }

    }
}