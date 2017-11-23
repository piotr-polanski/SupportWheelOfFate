using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Exceptions;
using SupportWheelOfFate.Domain.Model;

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

        protected override IEnumerable<SupportEngineer> FilterEngineers(IEnumerable<SupportEngineer> supportEngineersToFilter)
        {
            Ensure.That(supportEngineersToFilter, nameof(supportEngineersToFilter))
                .WithException(e => new NotEnoughEngineersException("Provided engineers list is null"))
                .IsNotNull();

            return supportEngineersToFilter
                .Where(se => (DateTime.Today - se.LastShiftDate).TotalDays > 1 );
        }
    }
}