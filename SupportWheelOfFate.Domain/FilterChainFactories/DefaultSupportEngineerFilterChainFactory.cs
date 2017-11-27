using System.Data;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.SupportEngineersFilters;

namespace SupportWheelOfFate.Domain.FilterChainFactories
{
    internal class DefaultSupportEngineerFilterChainFactory : ISupportEngineerFilterChainFactory
    {
        public ISupportEngineersFilterChain Create()
        {
            var logShiftFilter = new LogShiftForSelectedEngineersFilter();
            var randomFilter = new ChooseTwoRandomEngineersFilter(logShiftFilter);
            var engineersWhoDidntHadShiftYesterday = new EngineersWhoDidntHadShiftYesterdayFilter(randomFilter);
            var engineersWhoDidntHadTwoShiftsInLastTwoWeeks  = 
                new EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter(engineersWhoDidntHadShiftYesterday);
            return new ShiftSelectedTodayFilter(engineersWhoDidntHadTwoShiftsInLastTwoWeeks);

        }
    }
}