using System.Collections.Generic;
using FakeItEasy;
using Ploeh.AutoFixture;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class AbstractSupportEngineersFilterTests
    {
        [Fact]
        public void Filter_Given_MoreThanTwoEngineersAndSuccessor_Calls_Successor()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WithEngineersWhoHadShiftYesterday(10)
                .Build();
            var successor = A.Fake<ISupportEngineersFilterChain>();

            var sut = new ChooseTwoRandomEngineersFilter(successor);

            //act
            var result = sut.Filter(engineers);


            //assert
            A.CallTo(() => successor.Filter(A<IEnumerable<ISupportEngineer>>._))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

    }
}
