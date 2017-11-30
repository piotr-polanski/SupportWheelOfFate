using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-2))
                .Build();

            var engineer2WhoDidnHadShiftYesterday = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-2))
                .Build();

            var engineerWhoHadShiftYesterday = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-1))
                .Build();

            var engineerWhoHadTwoShiftsInLastTwoWeeks = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-3))
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-12))
                .Build();

            var engineer2WhoHadTwoShiftsInLastTwoWeeks = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-5))
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-11))
                .Build();

            var engineers = new List<ISupportEngineer>()
            {
                engineer2WhoHadTwoShiftsInLastTwoWeeks, engineerWhoHadShiftYesterday,
                engineerWhoHadTwoShiftsInLastTwoWeeks, engineer1WhoDidnHadShiftYesterday,
                engineer2WhoDidnHadShiftYesterday
            };

            var supportEngineerRepository = A.Fake<ISupportEngineersRepository>();
            var supportEngineersFactory = A.Fake<ISupportEngineersFactory>();
            A.CallTo(() => supportEngineersFactory.CreteSupportEngineers())
                .Returns(engineers);

            //var supportEngineersFactory = new SupportEngineers
            var filterChainFactory = new DefaultSupportEngineerFilterChainFactory();

            var sut = new WheelOfFate(supportEngineerRepository, supportEngineersFactory, filterChainFactory);

            //act
            var bauShift = sut.SelectTodaysBauShift();

            //assert
            bauShift.ShouldNotBeNull();
            bauShift.Shift.ShouldNotBeEmpty();
            //those two engineers had only one shift in shift log
            //we're checking if today shift was added to log
            //thats how we know if they were selected
            bauShift.Shift.First().ShiftLog.Count.ShouldBe(2);
            bauShift.Shift.Last().ShiftLog.Count.ShouldBe(2);
        }
    }
}
