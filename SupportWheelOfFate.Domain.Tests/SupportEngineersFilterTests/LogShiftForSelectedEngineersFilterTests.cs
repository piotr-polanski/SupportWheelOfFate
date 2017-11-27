using System.Linq;
using FakeItEasy;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class LogShiftForSelectedEngineersFilterTests
    {
        [Fact]
        public void Filter_Given_SelectedEngineers_Then_LogShifForThem()
        {
            //arrange
            var engineers = new SupportEngineerListBuilder()
                .WithEngineersAlreadySelectedForToday(2)
                .Build();
            var sut = new LogShiftForSelectedEngineersFilter();

            //act
            var result = sut.Filter(engineers);

            //assert
            foreach (var supportEngineer in result)
            {
                A.CallTo(() => supportEngineer.LogTodaysShift())
                    .MustHaveHappened(Repeated.Exactly.Once);
            }

        }
    }
}
