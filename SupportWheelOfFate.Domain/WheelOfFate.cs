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
        private readonly ISupportEngineersFactory _supportEngineersFactory;
        private readonly ISupportEngineerFilterChainFactory _supportEngineersFilterChainFactory;

        public WheelOfFate(ISupportEngineersRepository supportEngineersRepository, 
            ISupportEngineersFactory supportEngineersFactory, 
            ISupportEngineerFilterChainFactory supportEngineersFilterChainFactory)
        {
            _supportEngineersRepository = supportEngineersRepository;
            _supportEngineersFactory = supportEngineersFactory;
            _supportEngineersFilterChainFactory = supportEngineersFilterChainFactory;
        }

        public BauShift SelectTodaysBauShift()
        {
            var engineerDtos = _supportEngineersRepository.GetEngineerDtos();

            var avaliableEngineers = _supportEngineersFactory.CreteSupportEngineers(engineerDtos);

            var engineersFilterChain = _supportEngineersFilterChainFactory.Create();

            var theChosenOnes = engineersFilterChain.Filter(avaliableEngineers);

            var bauShift = new BauShift(theChosenOnes.First(), theChosenOnes.Last());

            _supportEngineersRepository.Save();

            return bauShift;
        }
    }
}