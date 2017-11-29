using System.Linq;
using Shouldly;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class PreferEngineersWhiDidntHadShiftInLastWeekFilterTest
    {
        [Fact]
        public void Filter_Given_EngineersWhoDidntHadShiftInLastFiveDays_Return_GivenEngineers()
        {
            //arrange
            var engineersWhiDidntHadShiftInLastFiveDays = new SupportEngineerListBuilder()
                .WithEngineersWhoDidntHadShiftInLastWeek(5)
                .Build();

            var sut = new PreferEngineersWhoDidintHadShiftInLastWeekFilter();

            //act
            var result = sut.Filter(engineersWhiDidntHadShiftInLastFiveDays);

            //assert
            result.ShouldBe(engineersWhiDidntHadShiftInLastFiveDays);
        }

        [Fact]
        public void Filter_Given_TwoEngineersWhoDidntHadShiftInLastWeek_And_FourEngineersWhoHad_Retrun_TwoWhoDidntHad()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WithEngineersWhoDidntHadShiftInLastWeek(2)
                .WihtEngineersWhoHadShiftInLastWeeks(4)
                .Build();

            var sut = new PreferEngineersWhoDidintHadShiftInLastWeekFilter();

            //act
            var result = sut.Filter(engineers);

            //assert
            result.Count().ShouldBe(2);
            result.Count(se => 
                se.Name == nameof(SupportEngineerListBuilder.WithEngineersWhoDidntHadShiftInLastWeek))
            .ShouldBe(2);
        }
    }
}
