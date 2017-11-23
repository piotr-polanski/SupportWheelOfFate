using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using SupportWheelOfFate.Domain.Exceptions;
using SupportWheelOfFate.Domain.Model;
using static EnsureThat.Ensure;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal class ChooseTwoRandomEngineersFilter : SupportEngineerFilterChain
    {
        public override IEnumerable<SupportEngineer> Filter(IEnumerable<SupportEngineer> supportEngineersToFilter)
        {
            That(supportEngineersToFilter, nameof(supportEngineersToFilter))
                .WithException(e => new NotEnoughEngineersException("Provided engineers list is null"))
                .IsNotNull();

            That(supportEngineersToFilter.Count(), nameof(supportEngineersToFilter))
                .WithException(e => new NotEnoughEngineersException("There is not enough avaliable engineers for BAU shift"))
                .IsGt(2);

            Random random = new Random();
            var supportEngineersList = supportEngineersToFilter.ToList();

            var morningShifIndex = random.Next(1, supportEngineersList.Count);
            var morningShiftEngineer = supportEngineersList.ElementAt(morningShifIndex);

            supportEngineersList.RemoveAt(morningShifIndex);

            var afterNoonShifIndex = random.Next(1, supportEngineersList.Count);
            var afterNoonShiftEngineer = supportEngineersList.ElementAt(afterNoonShifIndex);

            return new List<SupportEngineer>
            {
                morningShiftEngineer, afterNoonShiftEngineer
            };
        }

    }
}