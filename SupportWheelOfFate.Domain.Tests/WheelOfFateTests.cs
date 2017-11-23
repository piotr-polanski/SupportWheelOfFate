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
        public void SelectTodaysBAUShift_Returns_RandomlySelectedTwoFromAvaliableSupportEnginners()
        {
            //arrange
            var avaliableEngineers = _fixture.CreateMany<SupportEngineer>(10);
            WheelOfFate sut = new WheelOfFateBuilder()
                .With(avaliableEngineers)
                .Build();

            //act
            BauShift todaysBauShift = sut.SelectTodaysBauShift();

            //assert
            avaliableEngineers.ShouldContain(todaysBauShift.AfterNoonShiftEngineer);
            avaliableEngineers.ShouldContain(todaysBauShift.MorningShiftEngineer);

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
