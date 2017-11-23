using System;
using System.Linq;
using FakeItEasy;
using Ploeh.AutoFixture;
using Shouldly;
using SupportWheelOfFate.Domain;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using Xunit;

namespace SupportWhellOfFate.Domain.IntegrationTests
{
    public class WheelOfFateIntegrationTests
    {
        [Fact]
        public void SelectTodaysBauShift_Given_10Engineers_Returns_TwoEngineers()
        {
            //arrange
            var fixture = new Fixture();
            fixture.Customize<SupportEngineer>(se => se
                .With(s => s.LastShiftDate, DateTime.Today.AddDays(-1)));
            var engineers = fixture.CreateMany<SupportEngineer>(10);

            //set two engineers who didnt had shift yesterday
            engineers.First().LastShiftDate = DateTime.Today.AddDays(-2);
            engineers.Last().LastShiftDate = DateTime.Today.AddDays(-5);

            var supportEngineerRepository = A.Fake<ISupportEngineersRepository>();
            A.CallTo(() => supportEngineerRepository.GetEngineers())
                .Returns(engineers);
            var chooseTwoRandomEngineersFilter = new ChooseTwoRandomEngineersFilter();
            var engineersWhiDidntHadShiftYesterdayFilter = 
                new EngineersWhoDidntHadShiftYesterdayFilter(chooseTwoRandomEngineersFilter);

            var sut = new WheelOfFate(supportEngineerRepository, engineersWhiDidntHadShiftYesterdayFilter);

            //act
            var bauShift = sut.SelectTodaysBauShift();

            //assert
            bauShift.ShouldNotBeNull();
            bauShift.MorningShiftEngineer.ShouldNotBeNull();
            bauShift.AfterNoonShiftEngineer.ShouldNotBeNull();
        }

    }
}
