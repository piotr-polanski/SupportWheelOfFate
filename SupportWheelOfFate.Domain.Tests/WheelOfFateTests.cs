using System.Linq;
using FakeItEasy;
using Ploeh.AutoFixture;
using Shouldly;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests
{
    public class WheelOfFateTests
    {
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
            var supportEngineersFromFilter = new SupportEngineerMocksBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(2)
                .Build();
            WheelOfFate sut = new WheelOfFateBuilder()
                .WithSupportEngineersFromFilter(supportEngineersFromFilter)
                .Build();

            //act
            BauShift todaysBauShift = sut.SelectTodaysBauShift();

            //assert
            supportEngineersFromFilter.First().ShouldBe(todaysBauShift.MorningShiftEngineer);
            supportEngineersFromFilter.Last().ShouldBe(todaysBauShift.AfterNoonShiftEngineer);

        }

        [Fact]
        public void SelectTodaysBauShift_CallsSaveOnEngineersRepository()
        {
            //arrange
            var supportEngineersFactory = A.Fake<ISupportEngineersFactory>();
            var supportEngineersRepository = A.Fake<ISupportEngineersRepository>();
            var sut = new WheelOfFateBuilder()
                .WithSupportEngineersRepository(supportEngineersRepository)
                .WihtSupportEngineersFactory(supportEngineersFactory)
                .Build();

            //act
            var bauShift = sut.SelectTodaysBauShift();

            //assert
            A.CallTo(() => supportEngineersRepository.Save())
                .MustHaveHappened(Repeated.Exactly.Once);
        }

    }
}
