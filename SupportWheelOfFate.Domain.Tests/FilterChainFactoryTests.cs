using Shouldly;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests
{
    public class FilterChainFactoryTests
    {
        [Fact]
        public void Create_Returns_ChainedFilters()
        {
            //arrange
            var sut = new DefaultFilterChainFactory();

            //act
            var filterChain = sut.Create();

            //assert
            filterChain.ShouldBeOfType<EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter>();
            filterChain.Successor.ShouldBeOfType<EngineersWhoDidntHadShiftYesterdayFilter>();
            filterChain.Successor.Successor.ShouldBeOfType<ChooseTwoRandomEngineersFilter>();
            filterChain.Successor.Successor.Successor.ShouldBeNull();
        }
    }
}
