using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Shouldly;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Infrastructure;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWhellOfFate.Domain.IntegrationTests
{
    public class DefaultSupportEngineerFilterFactoryIntegrationTests
    {
        [Theory]
        [Repeat(100)]
        public void SelectTodaysBauShift_Given_10EngineersWith0Shifts_After10DaysOfShifts_EachEngineerHave20ShiftsLogged()
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

            var defaultSupportEngineerFilterChainFactory = new DefaultSupportEngineerFilterChainFactory();
            var sut = defaultSupportEngineerFilterChainFactory.Create();

            //act
            //at the beggining all engineers have 0 shifts
            foreach (var supportEngineer in tenSupportEngineersWithouthShifts)
            {
                supportEngineer.ShiftCount.ShouldBe(0);
            }
            ;
            //simulate ten days of shifts
            for (int daysToAdd = 0; daysToAdd < numberOfDays; daysToAdd++)
            {
                //simulate weekend
                if (daysToAdd == 5)
                    daysToAdd = daysToAdd + 2;
                A.CallTo(() => calendar.Today).Returns(DateTime.Today.AddDays(daysToAdd));
                sut.Filter(tenSupportEngineersWithouthShifts);
            }

            //assert
            foreach (var supportEngineer in tenSupportEngineersWithouthShifts)
            {
                supportEngineer.ShiftCount.ShouldBe(2);
            }
        }

        [Theory]
        [Repeat(100)]
        public void SelectTodaysBauShift_Given_10EngineersWith0Shifts_After10DaysOfShifts_EachEngineerDidntHadShiftInTwoCosequentDays()
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

            var defaultSupportEngineerFilterChainFactory = new DefaultSupportEngineerFilterChainFactory();
            var sut = defaultSupportEngineerFilterChainFactory.Create();

            //act
            //at the beggining all engineers have 0 shifts
            foreach (var supportEngineer in tenSupportEngineersWithouthShifts)
            {
                supportEngineer.ShiftCount.ShouldBe(0);
            }
            ;
            //simulate ten days of shifts
            for (int daysToAdd = 0; daysToAdd < numberOfDays; daysToAdd++)
            {
                //simulate weekend
                if (daysToAdd == 5) 
                    daysToAdd = daysToAdd + 2;

                A.CallTo(() => calendar.Today).Returns(DateTime.Today.AddDays(daysToAdd));

                sut.Filter(tenSupportEngineersWithouthShifts);
            }

            //assert
            foreach (var supportEngineer in tenSupportEngineersWithouthShifts)
            {
                var lastTwoShifts = supportEngineer.LastTwoShifts;
                var lastShift = lastTwoShifts.First();
                var secondToLastShift = lastTwoShifts.Last();
                ((lastShift.Date - secondToLastShift.Date).TotalDays > 1).ShouldBeTrue();
            }
        }
    }
}