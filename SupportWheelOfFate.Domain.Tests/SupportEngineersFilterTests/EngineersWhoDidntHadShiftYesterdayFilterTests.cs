using System;
using System.Linq;
using Ploeh.AutoFixture;
using Shouldly;
using SupportWheelOfFate.Domain.Exceptions;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class EngineersWhoDidntHadShiftYesterdayFilterTests
    {
        [Fact]
        public void Filter_Given_EngineersWhoDidntHadShiftYesterday_Return_SameAmountOfEngineers()
        {
            //arrange
            var fixture = new Fixture();
            fixture.Customize<SupportEngineer>(se => se
                .With(s => s.LastShiftDate, DateTime.Today.AddDays(-2)));
            var engineersWhoDidntHadShiftYesterday = fixture.CreateMany<SupportEngineer>(10);

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
            var fixture = new Fixture();
            fixture.Customize<SupportEngineer>(se => se
                .With(s => s.LastShiftDate, DateTime.Today.AddDays(-1)));
            var engineersWhoHadShiftYesterday = fixture.CreateMany<SupportEngineer>(10);

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
            var fixture = new Fixture();
            fixture.Customize<SupportEngineer>(se => se
                .With(s => s.LastShiftDate, DateTime.Today.AddDays(-1)));
            var engineers = fixture.CreateMany<SupportEngineer>(5);

            //Two engineers didn't had shift yesterday
            engineers.First().LastShiftDate = DateTime.Today.AddDays(-3);
            engineers.Last().LastShiftDate = DateTime.Today.AddDays(-3);

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