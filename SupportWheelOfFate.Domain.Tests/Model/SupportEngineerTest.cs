using System;
using System.Collections.Generic;
using Shouldly;
using SupportWheelOfFate.Domain.Model;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.Model
{
    public class SupportEngineerTest
    {
        [Fact]
        public void DidntHadShiftYesterday_When_EngieneerDidnHadShiftYesterday_Returns_True()
        {
            //arrange
            var sut = new SupportEngineer();

            //act
            var result = sut.DidntHadShiftYesterday();

            //assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void HadShiftYesterday_When_EngineerDidHadShiftYesterday_Returns_True()
        {
            //arrange
            var sut = new SupportEngineer();
            sut.ShiftLog.Add(DateTime.Today.AddDays(-1));

            //act
            var result = sut.HadShiftYesterday();

            //assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void DidntHadShiftYesterday_When_EngieneerDidHadShiftYesterday_Returns_False()
        {
            //arrange
            var sut = new SupportEngineer();
            sut.ShiftLog.Add(DateTime.Today.AddDays(-1));

            //act
            var result = sut.DidntHadShiftYesterday();

            //assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HadShiftYesterday_When_EngineerDidntHadShiftYesterday_Returns_False()
        {
            //arrange
            var sut = new SupportEngineer();

            //act
            var result = sut.HadShiftYesterday();

            //assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void LogTodaysShift_AddTodaysDateToShiftLog()
        {
            //arrange
            var sut = new SupportEngineer();

            //act
            sut.LogTodaysShift();

            //assert
            sut.ShiftLog.Count.ShouldBe(1);
        }
    }
}
