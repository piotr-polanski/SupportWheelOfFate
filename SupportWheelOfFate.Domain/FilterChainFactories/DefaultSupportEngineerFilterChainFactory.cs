using System.Data;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.SupportEngineersFilters;

namespace SupportWheelOfFate.Domain.FilterChainFactories
{
    internal class DefaultSupportEngineerFilterChainFactory : ISupportEngineerFilterChainFactory
    {
        public ISupportEngineersFilterChain Create()
        {
            return new ShiftSelectedTodayFilter(
                new PreferEngineersWhoDidintHadShiftInLastWeekFilter(
                    new EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter(
                        new EngineersWhoDidntHadShiftYesterdayFilter(
                            new ChooseTwoRandomEngineersFilter(
                                new LogShiftForSelectedEngineersFilter())))));

        }
    }
}