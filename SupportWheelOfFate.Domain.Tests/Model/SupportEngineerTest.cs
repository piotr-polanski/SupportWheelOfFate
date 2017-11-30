using System;
using System.Collections.Generic;
using FakeItEasy;
using Shouldly;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;
using Xunit;
using SupportWheelOfFate.Domain.Tests.Builders;

namespace SupportWheelOfFate.Domain.Tests.Model
{
    public class SupportEngineerTest
    {
        [Fact]
        public void DidntHadShiftYesterday_When_EngieneerDidnHadShiftYesterday_Returns_True()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .Build();

            //act
            var result = sut.DidntHadShiftYesterday();

            //assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void HadShiftYesterday_When_EngineerDidHadShiftYesterday_Returns_True()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-1))
                .Build();

            //act
            var result = sut.HadShiftYesterday();

            //assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void DidntHadShiftYesterday_When_EngieneerDidHadShiftYesterday_Returns_False()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-1))
                .Build();

            //act
            var result = sut.DidntHadShiftYesterday();

            //assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HadShiftYesterday_When_EngineerDidntHadShiftYesterday_Returns_False()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .Build();

            //act
            var result = sut.HadShiftYesterday();

            //assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void LogTodaysShift_AddTodaysDateToShiftLog()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .Build();

            //act
            sut.LogTodaysShift();

            //assert
            sut.ShiftCount.ShouldBe(1);
        }

        [Theory, MemberData("DatesTwoWeeksAgo")]
        public void DidntHadTwoShiftsInLastTwoWeeks_When_InFactHeDidntHad_Return_True(DateTime someDate,
            DateTime someOtherDate)
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(someDate)
                .WithShiftLoggedOnDate(someOtherDate)
                .Build();

            //act
            var result = sut.DidntHadTwoShiftInLastTwoWeeks();

            //assert
            result.ShouldBeTrue();
        }

        public static List<object[]> DatesTwoWeeksAgo()
        {
            return new List<object[]>()
            {
                new object[] {DateTime.Today.AddDays(-15), null},
                new object[] {DateTime.Today.AddDays(-6), null},
                new object[] {DateTime.Today.AddDays(-11), DateTime.Today.AddDays(-16)},
                new object[] {DateTime.Today.AddDays(-15), DateTime.Today.AddDays(-16)},
                new object[] {DateTime.Today.AddDays(-23), DateTime.Today.AddDays(-14)},
                new object[] {DateTime.Today.AddDays(-15), DateTime.Today.AddDays(-14)},
            };
        }

        [Theory, MemberData("DatesWithinTwoWeeks")]
        public void HadTwoShiftsInLastTwoWeeks_When_InFactHeDid_Return_True(DateTime someDate, DateTime someOtherDate)
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(someDate)
                .WithShiftLoggedOnDate(someOtherDate)
                .Build();

            //act
            var result = sut.HadTwoShiftsInLastTwoWeeks();

            //assert
            result.ShouldBeTrue();
        }

        public static List<object[]> DatesWithinTwoWeeks()
        {
            return new List<object[]>()
            {
                new object[] {DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-6)},
                new object[] {DateTime.Today.AddDays(-13), DateTime.Today.AddDays(-13)},
                new object[] {DateTime.Today.AddDays(-14), DateTime.Today.AddDays(-14)},
            };
        }

        [Fact]
        public void HaveShiftToday_When_HeHaveShiftToday_Returns_True()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today)
                .Build();

            //act
            var result = sut.HaveShiftToday();

            //assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void HaveShiftToday_When_HeDoesntHaveShiftToday_Returns_False()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-1))
                .Build();

            //act
            var result = sut.HaveShiftToday();

            //assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HaveShiftToday_When_HeDidntHadeAnyShiftsAtAll_Returns_False()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .Build();

            //act
            var result = sut.HaveShiftToday();

            //assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void DidntHadShiftInLastFiveDays_Given_HeDidntHadAnyShift_Return_True()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .Build();

            //act
            var result = sut.DidntHadShiftInLastWeek();

            //assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void DidntHadShiftInLastFiveDays_Given_HeDidntHad_Return_True()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-8))
                .Build();

            //act
            var result = sut.DidntHadShiftInLastWeek();

            //assert
            result.ShouldBeTrue();

        }

        [Fact]
        public void DidntHadShiftInLastFiveDays_Given_HeHad_Return_False()
        {
            //arrange
            var sut = new SupportEngineerBuilder()
                .WithShiftLoggedOnDate(DateTime.Today.AddDays(-7))
                .Build();

            //act
            var result = sut.DidntHadShiftInLastWeek();

            //assert
            result.ShouldBeFalse();

        }
    }
}
