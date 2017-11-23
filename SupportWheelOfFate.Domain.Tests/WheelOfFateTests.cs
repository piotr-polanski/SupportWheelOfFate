using Shouldly;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests
{
    public class WheelOfFateTests
    {
        [Fact]
        public void SelectTodaysBAUShift_Returns_BAUShift()
        {
            //arrange
            WheelOfFate sut = new WheelOfFate();

            //act
            BAUShift todaysBAUShift = sut.SelectTodaysBAUShift();

            //assert
            todaysBAUShift.ShouldNotBeNull();
        }

        [Fact]
        public void SelectTodaysBAUShif_Returns_BAUShiftWithTwoEngineers()
        {
            //arrange
            WheelOfFate sut = new WheelOfFate();

            //act
            BAUShift todaysBAUShift = sut.SelectTodaysBAUShift();

            //assert
            todaysBAUShift.MorningShiftEngineer.ShouldNotBeNull();
            todaysBAUShift.AfterNoonShiftEngineer.ShouldNotBeNull();
        }
    }
}
