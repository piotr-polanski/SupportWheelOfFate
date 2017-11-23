using Xunit;

namespace SupportWheelOfFate.Domain.Tests
{
    public class WheelOfFateTests
    {
        [Fact]
        public void SelectTodaysBAUShift_Returns_BAUShift()
        {
            //arrange
            var sut = new WheelOfFate();

            //act
            BAUShift todaysBAUShift = sut.SelectTodaysBAUShift();

            //assert
            Assert.NotNull(todaysBAUShift);

        }
    }
}
