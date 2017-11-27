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
            var engineer1WhoDidnHadShiftYesterday = new SupportEngineerBuilder()
                .WithShiftLoggedFromNow(-2)
                .Build();

            var engineer2WhoDidnHadShiftYesterday = new SupportEngineerBuilder()
                .WithShiftLoggedFromNow(-2)
                .Build();

            var engineerWhoHadShiftYesterday = new SupportEngineerBuilder()
                .WithShiftLoggedFromNow(-1)
                .Build();

            var engineerWhoHadTwoShiftsInLastTwoWeeks = new SupportEngineerBuilder()
                .WithShiftLoggedFromNow(-3)
                .WithShiftLoggedFromNow(-12)
                .Build();

            var engineer2WhoHadTwoShiftsInLastTwoWeeks = new SupportEngineerBuilder()
                .WithShiftLoggedFromNow(-5)
                .WithShiftLoggedFromNow(-11)
                .Build();

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
