using System.Collections.Generic;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal class LogShiftForSelectedEngineersFilter : SupportEngineerFilterChain
    {
        public LogShiftForSelectedEngineersFilter() : base(null)
        {
        }

        public LogShiftForSelectedEngineersFilter(ISupportEngineersFilterChain successor) : base(successor)
        {
        }

        protected override IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineers)
        {
            foreach (var supportEngineer in supportEngineers)
            {
                supportEngineer.LogTodaysShift();
            }
            return supportEngineers;
        }
    }
}