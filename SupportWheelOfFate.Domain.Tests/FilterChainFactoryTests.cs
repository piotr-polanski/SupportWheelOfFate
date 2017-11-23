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
            filterChain.ShouldBeOfType<EngineersWhoDidntHadShiftYesterdayFilter>();
            filterChain.Successor.ShouldBeOfType<ChooseTwoRandomEngineersFilter>();
            filterChain.Successor.Successor.ShouldBeNull();
        }
    }
}
