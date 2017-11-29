using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal class ShiftSelectedTodayFilter : SupportEngineerFilterChain
    {
        public ShiftSelectedTodayFilter(ISupportEngineersFilterChain successor) : base(successor)
        {
        }

        public ShiftSelectedTodayFilter() : base(null)
        {
        }

        protected override IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineers)
        {
            var todaysShift =
                supportEngineers.Where(e => e.HaveShiftToday());

            if (todaysShift.Any())
            {
                BrakeTheChain();
                return todaysShift;
            }
            return supportEngineers;
        }

    }
}