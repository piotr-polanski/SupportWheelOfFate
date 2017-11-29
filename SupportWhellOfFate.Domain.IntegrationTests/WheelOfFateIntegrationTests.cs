using System;
using System.Collections.Generic;
using System.IO;
using FakeItEasy;
using Shouldly;
using SupportWheelOfFate.Domain;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.Repository;
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
            bauShift.MorningShiftEngineer.ShouldNotBeNull();
            bauShift.AfterNoonShiftEngineer.ShouldNotBeNull();
            //those two engineers had only one shift in shift log
            //we're checking if today shift was added to log
            //thats how we know if they were selected
            bauShift.MorningShiftEngineer.ShiftLog.Count.ShouldBe(2);
            bauShift.AfterNoonShiftEngineer.ShiftLog.Count.ShouldBe(2);
        }

        [Theory]
        [Repeat(100)]
        public void SelectTodaysBauShift_Given_10ENgineersWith0Shifts_After10DaysOfShifts_EachEngineerHave2ShiftsLogged()
        {
            //arrange
            int numberOfEngineers = 10;
            int numberOfDays = 12;
            ICalendar calendar = A.Fake<ICalendar>();
            IList<ISupportEngineer> tenSupportEngineersWithouthShifts = new List<ISupportEngineer>();
            for (int i = 0; i < numberOfEngineers; i++)
            {
                tenSupportEngineersWithouthShifts.Add(new SupportEngineerBuilder()
                    .WihtDateProvider(calendar)
                    .Build());
            }
            ISupportEngineersFactory supportEngineersFactory = A.Fake<ISupportEngineersFactory>();

            ISupportEngineersRepository supportEngineersRepository = A.Fake<ISupportEngineersRepository>();
            A.CallTo(() => supportEngineersFactory.CreteSupportEngineers())
                .Returns(tenSupportEngineersWithouthShifts);
            var sut = new WheelOfFate(supportEngineersRepository, supportEngineersFactory, new DefaultSupportEngineerFilterChainFactory());

            //act
            //at the beggining all engineers have 0 shifts
            foreach (var supportEngineer in tenSupportEngineersWithouthShifts)
            {
                supportEngineer.ShiftLog.Count.ShouldBe(0);
            }
;
            //simulate ten days of shifts
            for (int daysToAdd = 0; daysToAdd < numberOfDays; daysToAdd++)
            {
                //simulate weekend
                if (daysToAdd == 5)
                    daysToAdd = daysToAdd + 2;
                A.CallTo(() => calendar.Today).Returns(DateTime.Today.AddDays(daysToAdd));
                sut.SelectTodaysBauShift();
            }

            //assert
            foreach (var supportEngineer in tenSupportEngineersWithouthShifts)
            {
               supportEngineer.ShiftLog.Count.ShouldBe(2);
            }
        }

    }
}
