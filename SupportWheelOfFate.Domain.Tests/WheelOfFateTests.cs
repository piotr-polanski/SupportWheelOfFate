using System.Linq;
using Ploeh.AutoFixture;
using Shouldly;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests
{
    public class WheelOfFateTests
    {
        private readonly Fixture _fixture;

        public WheelOfFateTests()
        {
            _fixture = new Fixture();
        }
        [Fact]
        public void SelectTodaysBAUShift_Returns_BAUShift()
        {
            //arrange
            WheelOfFate sut = new WheelOfFateBuilder().Build();

            //act
            BauShift todaysBauShift = sut.SelectTodaysBauShift();

            //assert
            todaysBauShift.ShouldNotBeNull();
        }

        [Fact]
        public void SelectTodaysBAUShif_Returns_BAUShiftWithTwoEngineers()
        {
            //arrange
            WheelOfFate sut = new WheelOfFateBuilder().Build();

            //act
            BauShift todaysBauShift = sut.SelectTodaysBauShift();

            //assert
            todaysBauShift.MorningShiftEngineer.ShouldNotBeNull();
            todaysBauShift.AfterNoonShiftEngineer.ShouldNotBeNull();
        }

        [Fact]
        public void SelectTodaysBAUShift_Returns_BauShiftWithFirstAndLastFromFilteredOutEngineers()
        {
            //arrange
            var supportEngineersFromFilter = _fixture.CreateMany<SupportEngineer>(2);
            WheelOfFate sut = new WheelOfFateBuilder()
                .WithSupportEngineersFromFilter(supportEngineersFromFilter)
                .Build();

            //act
            BauShift todaysBauShift = sut.SelectTodaysBauShift();

            //assert
            supportEngineersFromFilter.First().ShouldBe(todaysBauShift.MorningShiftEngineer);
            supportEngineersFromFilter.Last().ShouldBe(todaysBauShift.AfterNoonShiftEngineer);

        }

        //[Fact]
        //public void SelectTodaysBAUShift_When_NoSupportEngineers_Then_ThrowsNoAvaliableSupportEngineersException()
        //{
        //    Assert.True(false);
        //}
        
        //[Fact]
        //public void SelectTodaysBAUShift_When_OnlyOneSupportEngineerAvaliable_Then_ThrowsOnlyOneSupportEngineerAvaliableException()
        //{
        //    Assert.True(false);
        //}
    }
}
