using System;
using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal class ChooseTwoRandomEngineersFilter : SupportEngineerFilterChain
    {
        public ChooseTwoRandomEngineersFilter() : base(null)
        {
        }

        public ChooseTwoRandomEngineersFilter(ISupportEngineersFilterChain successor): base(successor)
        {
        }

        protected override IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineersToFilter)
        {
            Random random = new Random();
            var supportEngineersList = supportEngineersToFilter.ToList();

            var morningShifIndex = random.Next(0, supportEngineersList.Count);
            var morningShiftEngineer = supportEngineersList.ElementAt(morningShifIndex);

            supportEngineersList.RemoveAt(morningShifIndex);

            var afterNoonShifIndex = random.Next(0, supportEngineersList.Count);
            var afterNoonShiftEngineer = supportEngineersList.ElementAt(afterNoonShifIndex);

            return new List<ISupportEngineer>
            {
                morningShiftEngineer, afterNoonShiftEngineer
            };
        }

    }
}