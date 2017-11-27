using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Shouldly;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class ShiftSelectedTodayFilterTests
    {
        [Fact]
        public void
            Filter_Given_MoreThanTwoEngineersAndSuccessor_When_ShiftWasAlreadySelectedToday_SuccessorIsNotCalled()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(8)
                .WithEngineersAlreadySelectedForToday(2)
                .Build();

            var successor = A.Fake<ISupportEngineersFilterChain>();

            var sut = new ShiftSelectedTodayFilter(successor);

            //act
            var result = sut.Filter(engineers);

            //assert
            A.CallTo(() => successor.Filter(A<IEnumerable<ISupportEngineer>>._))
                .MustNotHaveHappened();
        }

        [Fact]
        public void
            Filter_Given_MoreThanTwoEngineersAndSuccessor_When_ShiftWasAlreadySelectedToday_Return_AlreadySelectedEngineers()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(8)
                .WithEngineersAlreadySelectedForToday(2)
                .Build();

            var successor = A.Fake<ISupportEngineersFilterChain>();

            var sut = new ShiftSelectedTodayFilter(successor);

            //act
            var result = sut.Filter(engineers);

            //assert
            result.First().Name
                .ShouldBe(nameof(SupportEngineerListBuilder.WithEngineersAlreadySelectedForToday));
            result.Last().Name
                .ShouldBe(nameof(SupportEngineerListBuilder.WithEngineersAlreadySelectedForToday));
        }

        [Fact]
        public void Filter_Given_10Engineers_When_ShiftWasntSelectedToday_Return_AllGivenEngineers()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WihtEngineersWhoDidntHadTwoShiftInLastTwoWeeks(10)
                .Build();

            var sut = new ShiftSelectedTodayFilter();

            //act
            var result = sut.Filter(engineers);

            //assert
            result.Count().ShouldBe(engineers.Count());
        }

        [Fact]
        public void Filter_Given_10Engineers_When_ShiftWasntSelectedToday_Then_CallSuccessor()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WihtEngineersWhoDidntHadTwoShiftInLastTwoWeeks(10)
                .Build();
            var successor = A.Fake<ISupportEngineersFilterChain>();

            var sut = new ShiftSelectedTodayFilter(successor);

            //act
            var result = sut.Filter(engineers);

            //assert
            A.CallTo(() => successor.Filter(A<IEnumerable<ISupportEngineer>>._))
                .MustHaveHappened(Repeated.Exactly.Once);

        }
    }
}
