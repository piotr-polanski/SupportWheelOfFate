using System;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain
{
    public class WheelOfFate
    {
        private readonly ISupportEngineersRepository _supportEngineersRepository;
        private readonly ISupportEngineersFilterChain _supportEngineersFilter;

        internal WheelOfFate(ISupportEngineersRepository supportEngineersRepository, ISupportEngineersFilterChain supportEngineersFilter)
        {
            _supportEngineersRepository = supportEngineersRepository;
            _supportEngineersFilter = supportEngineersFilter;
        }

        public BauShift SelectTodaysBauShift()
        {
            var avaliableEngineers = _supportEngineersRepository.GetEngineers();

            var theChosenOnes = _supportEngineersFilter.Filter(avaliableEngineers);

            return new BauShift(theChosenOnes.First(), theChosenOnes.Last());
        }
    }
}