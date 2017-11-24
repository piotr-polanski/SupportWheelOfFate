using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Ploeh.AutoFixture;
using Shouldly;
using SupportWheelOfFate.Domain.Exceptions;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class EngineersWhoDidntHadShiftYesterdayFilterTests
    {
        [Fact]
        public void Filter_Given_EngineersWhoDidntHadShiftYesterday_Return_SameAmountOfEngineers()
        {
            //arrange

            var engineersWhoDidntHadShiftYesterday = new SupportEngineerListBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(4)
                .Build();

            var sut = new EngineersWhoDidntHadShiftYesterdayFilter();

            //act
            var enginerrsAvaliableForShift = sut.Filter(engineersWhoDidntHadShiftYesterday);

            //assert
            enginerrsAvaliableForShift.Count().ShouldBe(engineersWhoDidntHadShiftYesterday.Count());
        }

        

        [Fact]
        public void Filter_Given_EngineersWhoHadShiftYesterday_Return_EmptyCollection()
        {
            //arrange
            var engineersWhoHadShiftYesterday = new SupportEngineerListBuilder()
                .WithEngineersWhoHadShiftYesterday(10)
                .Build();

            var sut = new EngineersWhoDidntHadShiftYesterdayFilter();

            //act
            var enginerrsAvaliableForShift = sut.Filter(engineersWhoHadShiftYesterday);

            //assert
            enginerrsAvaliableForShift.ShouldBeEmpty();
        }



        [Fact]
        public void Filter_Given_Engineers_Returns_OnlyThoseWhoDidntHadShiftYesterday()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WithEngineersWhoHadShiftYesterday(8)
                .WithEngineersWhoDidntHadShiftYesterday(2)
                .Build();


            var sut = new EngineersWhoDidntHadShiftYesterdayFilter();

            //act
            var avaliableEngineers = sut.Filter(engineers);

            //assert
            avaliableEngineers.Count().ShouldBe(2);
        }

        [Fact]
        public void Filter_Given_Null_Throws_NotEnoughEngineersException()
        {
            //arrange
            var sut = new EngineersWhoDidntHadShiftYesterdayFilter();

            //act and assert
            Assert.Throws<NotEnoughEngineersException>(() => sut.Filter(null));
        }
    }
} 