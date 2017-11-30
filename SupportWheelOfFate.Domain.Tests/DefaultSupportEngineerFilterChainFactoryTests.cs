using Shouldly;
using SupportWheelOfFate.Domain.Infrastructure;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests
{
    public class DefaultSupportEngineerFilterChainFactoryTests
    {
        [Fact]
        public void Create_Returns_ChainedFilters()
        {
            //arrange
            var sut = new DefaultSupportEngineerFilterChainFactory();

            //act
            var filterChain = sut.Create();

            //assert
            filterChain.ShouldBeOfType<ShiftSelectedTodayFilter>();
            filterChain.Successor.ShouldBeOfType<PreferEngineersWhoDidintHadShiftInLastWeekFilter>();
            filterChain.Successor.Successor.ShouldBeOfType<EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter>();
            filterChain.Successor.Successor.Successor.ShouldBeOfType<EngineersWhoDidntHadShiftYesterdayFilter>();
            filterChain.Successor.Successor.Successor.Successor.ShouldBeOfType<ChooseTwoRandomEngineersFilter>();
            filterChain.Successor.Successor.Successor.Successor.Successor
                .ShouldBeOfType<LogShiftForSelectedEngineersFilter>();
            filterChain.Successor.Successor.Successor.Successor.Successor.Successor.ShouldBeNull();
        }
    }
}
