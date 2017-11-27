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
            //thats why we know if they were selected
            bauShift.MorningShiftEngineer.ShiftLog.Count.ShouldBe(2);
            bauShift.AfterNoonShiftEngineer.ShiftLog.Count.ShouldBe(2);
        }

        [Fact]
        public void SelectTodaysBauShift_Given_ShiftAlredySelectedToday_Returns_TodayShift()
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

            var enginnerOneWhoWasSelectedToday = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today)
                .Build();

            var enginnerTwoWhoWasSelectedToday = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today)
                .Build();


            var engineers = new List<ISupportEngineer>()
            {
                engineer2WhoHadTwoShiftsInLastTwoWeeks, engineerWhoHadShiftYesterday,
                engineerWhoHadTwoShiftsInLastTwoWeeks, engineer1WhoDidnHadShiftYesterday,
                engineer2WhoDidnHadShiftYesterday, enginnerOneWhoWasSelectedToday,
                enginnerTwoWhoWasSelectedToday
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
            var shiftEgineers = new List<ISupportEngineer>()
            {
                bauShift.MorningShiftEngineer,
                bauShift.AfterNoonShiftEngineer
            };
            shiftEgineers.ShouldContain(enginnerOneWhoWasSelectedToday);
            shiftEgineers.ShouldContain(enginnerTwoWhoWasSelectedToday);
        }

    }
}
