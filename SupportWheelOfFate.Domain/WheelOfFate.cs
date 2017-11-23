using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain
{
    public class WheelOfFate
    {
        private readonly ISupportEngineersRepository _supportEngineersRepository;
        private readonly IFilterChainFactory _filterChainFactory;

        internal WheelOfFate(ISupportEngineersRepository supportEngineersRepository, 
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

            return new BauShift(theChosenOnes.First(), theChosenOnes.Last());
        }
    }
}