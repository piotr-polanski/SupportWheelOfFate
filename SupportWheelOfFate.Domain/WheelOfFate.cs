using System;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain
{
    public class WheelOfFate : IWheelOfFate
    {
        private readonly ISupportEngineersRepository _supportEngineersRepository;
        private readonly IFilterChainFactory _filterChainFactory;

        public WheelOfFate(ISupportEngineersRepository supportEngineersRepository, 
            IFilterChainFactory filterChainFactory)
        {
            _supportEngineersRepository = supportEngineersRepository;
            _filterChainFactory = filterChainFactory;
        }

        public BauShift SelectTodaysBauShift()
        {
            var avaliableEngineers = _supportEngineersRepository.GetEngineers();

            var filterChain = _filterChainFactory.Create();

            var theChosenOnes = filterChain.Filter(avaliableEngineers);

            var bauShift = new BauShift(theChosenOnes.First(), theChosenOnes.Last());

            bauShift.MorningShiftEngineer.LogTodaysShift();
            bauShift.AfterNoonShiftEngineer.LogTodaysShift();

            _supportEngineersRepository.Save();

            return bauShift;
        }
    }
}