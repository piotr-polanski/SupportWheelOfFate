using System;
using System.Collections.Generic;
using FakeItEasy;
using Shouldly;
using SupportWheelOfFate.Domain;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWhellOfFate.Domain.IntegrationTests
{
    public class WheelOfFateIntegrationTests
    {
        [Fact]
        public void SelectTodaysBauShift_Given_16Engineers_Returns_TwoEngineers()
        {
            //arrange
            var engineer1WhoDidnHadShiftYesterday = new SupportEngineer();
            engineer1WhoDidnHadShiftYesterday.ShiftLog.Add(DateTime.Today.AddDays(-2));

            var engineer2WhoDidnHadShiftYesterday = new SupportEngineer();
            engineer2WhoDidnHadShiftYesterday.ShiftLog.Add(DateTime.Today.AddDays(-2));

            var engineerWhoHadShiftYesterday = new SupportEngineer();
            engineerWhoHadShiftYesterday.ShiftLog.Add(DateTime.Today.AddDays(-1));

            var engineerWhoHadTwoShiftsInLastTwoWeeks = new SupportEngineer();
            engineerWhoHadTwoShiftsInLastTwoWeeks.ShiftLog.Add(DateTime.Today.AddDays(-3));
            engineerWhoHadTwoShiftsInLastTwoWeeks.ShiftLog.Add(DateTime.Today.AddDays(-12));

            var engineer2WhoHadTwoShiftsInLastTwoWeeks = new SupportEngineer();
            engineer2WhoHadTwoShiftsInLastTwoWeeks.ShiftLog.Add(DateTime.Today.AddDays(-5));
            engineer2WhoHadTwoShiftsInLastTwoWeeks.ShiftLog.Add(DateTime.Today.AddDays(-11));

            var engineers = new List<ISupportEngineer>()
            {
                engineer2WhoHadTwoShiftsInLastTwoWeeks, engineerWhoHadShiftYesterday,
                engineerWhoHadTwoShiftsInLastTwoWeeks, engineer1WhoDidnHadShiftYesterday,
                engineer2WhoDidnHadShiftYesterday
            };

            var supportEngineerRepository = A.Fake<ISupportEngineersRepository>();
            A.CallTo(() => supportEngineerRepository.GetEngineers())
                .Returns(engineers);

            var filterChainFactory = new DefaultFilterChainFactory();

            var sut = new WheelOfFate(supportEngineerRepository, filterChainFactory);

            //act
            var bauShift = sut.SelectTodaysBauShift();

            //assert
            bauShift.ShouldNotBeNull();
            bauShift.MorningShiftEngineer.ShouldNotBeNull();
            bauShift.AfterNoonShiftEngineer.ShouldNotBeNull();
            //those two engineers had only one shift in shift log
            //we're checking if today shift was added to log
            bauShift.MorningShiftEngineer.ShiftLog.Count.ShouldBe(2);
            bauShift.AfterNoonShiftEngineer.ShiftLog.Count.ShouldBe(2);
        }

    }
}
