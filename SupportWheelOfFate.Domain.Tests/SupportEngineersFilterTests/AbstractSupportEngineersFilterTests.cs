using System.Collections.Generic;
using FakeItEasy;
using Ploeh.AutoFixture;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class AbstractSupportEngineersFilterTests
    {
        [Fact]
        public void Filter_Given_MoreThanTwoEngineersAndSuccessor_Calls_Successor()
        {
            //arrange
            var engineers = new Fixture().CreateMany<SupportEngineer>(10);
            var successor = A.Fake<ISupportEngineersFilterChain>();

            var sut = new ChooseTwoRandomEngineersFilter(successor);

            //act
            var result = sut.Filter(engineers);


            //assert
            A.CallTo(() => successor.Filter(A<IEnumerable<SupportEngineer>>._))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
