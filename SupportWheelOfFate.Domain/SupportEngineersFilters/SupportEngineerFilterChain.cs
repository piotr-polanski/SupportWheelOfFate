using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Exceptions;

namespace SupportWheelOfFate.Domain.SupportEngineersFilters
{
    internal abstract class SupportEngineerFilterChain : ISupportEngineersFilterChain
    {
        protected SupportEngineerFilterChain(ISupportEngineersFilterChain successor)
        {
            Successor = successor;
        }

        private bool shouldBrakeChain;

        public ISupportEngineersFilterChain Successor { get; }

        public IEnumerable<ISupportEngineer> Filter(IEnumerable<ISupportEngineer> supportEngineersToFilter)
        {
            ValidateSupportEngineers(supportEngineersToFilter);

            var filteredEngineers = FilterEngineers(supportEngineersToFilter);

            return Successor == null || shouldBrakeChain ? filteredEngineers : Successor.Filter(filteredEngineers);
        }

        private static void ValidateSupportEngineers(IEnumerable<ISupportEngineer> supportEngineersToFilter)
        {
            Ensure.That(supportEngineersToFilter, nameof(supportEngineersToFilter))
                .WithException(e => new NotEnoughEngineersException("Provided engineers list is null"))
                .IsNotNull();

            Ensure.That(supportEngineersToFilter.Count(), nameof(supportEngineersToFilter))
                .WithException(e => new NotEnoughEngineersException("There is not enough avaliable engineers for BAU shift"))
                .IsGt(1);
        }

        protected void BrakeTheChain()
        {
            shouldBrakeChain = true;
        }
        protected abstract IEnumerable<ISupportEngineer> FilterEngineers(IEnumerable<ISupportEngineer> supportEngineers);

    }
}