using System.Linq;
using Shouldly;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilterTests
    {
        [Fact]
        public void Filter_Given_SupportEngineersWhoDidntHaveShiftInLastTwoWeeks_Retrun_AllGivenEngineers()
        {
            //arrange
            var engineersWheDidntHaveShiftInLastTwoWees = new SupportEngineerListBuilder()
                .WihtEngineersWhoDidntHadTwoShiftInLastTwoWeeks(5)
                .Build();
            var sut = new EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter();

            //act
            var filteredEngineers = sut.Filter(engineersWheDidntHaveShiftInLastTwoWees);

            //assert
            filteredEngineers.Count().ShouldBe(engineersWheDidntHaveShiftInLastTwoWees.Count());
        }

        [Fact]
        public void Filter_Given_SupportEngineersWhoHadShiftInLastTwoWeeks_Retrun_EmptyCollection()
        {
            //arrange
            var engineersWheDidntHaveShiftInLastTwoWees = new SupportEngineerListBuilder()
                .WihtEngineersWhoHadTwoShiftInLastTwoWeeks(5)
                .Build();
            var sut = new EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter();

            //act
            var filteredEngineers = sut.Filter(engineersWheDidntHaveShiftInLastTwoWees);

            //assert
            filteredEngineers.ShouldBeEmpty();
        }

        [Fact]
        public void Filter_Given_SupportEngineers_Retrun_OnlyThoseWheDidntHadTwoShiftsInLastTwoWeeks()
        {
            //arrange
            var engineersWheDidntHaveShiftInLastTwoWees = new SupportEngineerListBuilder()
                .WihtEngineersWhoHadTwoShiftInLastTwoWeeks(5)
                .WihtEngineersWhoDidntHadTwoShiftInLastTwoWeeks(12)
                .Build();
            var sut = new EngineersWhoDidntHadTwoShiftsInLastTwoWeeksFilter();

            //act
            var filteredEngineers = sut.Filter(engineersWheDidntHaveShiftInLastTwoWees);

            //assert
            filteredEngineers.Count().ShouldBe(12);
        }
    }
}
