using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.SupportEngineersFilters;

namespace SupportWheelOfFate.Domain.FilterChainFactories
{
    internal class DefaultFilterChainFactory : IFilterChainFactory
    {
        public ISupportEngineersFilterChain Create()
        {
            var randomFilter = new ChooseTwoRandomEngineersFilter();
            
            var engineersWhoDidntHadShiftYesterday = new EngineersWhoDidntHadShiftYesterdayFilter(randomFilter);

            return new EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter(engineersWhoDidntHadShiftYesterday);
        }
    }
}