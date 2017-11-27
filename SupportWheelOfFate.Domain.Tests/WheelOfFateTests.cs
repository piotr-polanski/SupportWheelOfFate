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
            var supportEngineersFromFilter = new SupportEngineerListBuilder()
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
        public void SelectTodaysBauShift_BauShiftIsAddingShiftDateToChosenEngineers()
        {
            //arrange
            var supportEngineersFromFilter = new SupportEngineerListBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(2)
                .Build();
            var sut = new WheelOfFateBuilder()
                .WithSupportEngineersFromFilter(supportEngineersFromFilter)
                .Build();

            //act
            var bauShift = sut.SelectTodaysBauShift();

            //assert
            A.CallTo(() => supportEngineersFromFilter.First().LogTodaysShift())
                .MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => supportEngineersFromFilter.Last().LogTodaysShift())
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void SelectTodaysBauShift_CallsSaveOnEngineersRepository()
        {
            //arrange
            var supportEngineersRepository = A.Fake<ISupportEngineersRepository>();
            var sut = new WheelOfFateBuilder()
                .WihtSupportEngineersRpository(supportEngineersRepository)
                .Build();

            //act
            var bauShift = sut.SelectTodaysBauShift();

            //assert
            A.CallTo(() => supportEngineersRepository.Save())
                .MustHaveHappened(Repeated.Exactly.Once);
        }

    }
}
