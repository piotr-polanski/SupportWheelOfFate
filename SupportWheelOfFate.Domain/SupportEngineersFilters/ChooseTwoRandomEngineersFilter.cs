using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Exceptions;
using SupportWheelOfFate.Domain.Model;
using static EnsureThat.Ensure;

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
            That(supportEngineersToFilter, nameof(supportEngineersToFilter))
                .WithException(e => new NotEnoughEngineersException("Provided engineers list is null"))
                .IsNotNull();

            That(supportEngineersToFilter.Count(), nameof(supportEngineersToFilter))
                .WithException(e => new NotEnoughEngineersException("There is not enough avaliable engineers for BAU shift"))
                .IsGt(1);

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