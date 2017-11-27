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
        private readonly ISupportEngineerFilterChainFactory _supportEngineersFilterChainFactory;

        public WheelOfFate(ISupportEngineersRepository supportEngineersRepository, 
            ISupportEngineerFilterChainFactory supportEngineersFilterChainFactory)
        {
            _supportEngineersRepository = supportEngineersRepository;
            _supportEngineersFilterChainFactory = supportEngineersFilterChainFactory;
        }

        public BauShift SelectTodaysBauShift()
        {
            var avaliableEngineers = _supportEngineersRepository.GetEngineers();

            var engineersFilterChain = _supportEngineersFilterChainFactory.Create();

            var theChosenOnes = engineersFilterChain.Filter(avaliableEngineers);

            var bauShift = new BauShift(theChosenOnes.First(), theChosenOnes.Last());

            _supportEngineersRepository.Save();

            return bauShift;
        }
    }
}