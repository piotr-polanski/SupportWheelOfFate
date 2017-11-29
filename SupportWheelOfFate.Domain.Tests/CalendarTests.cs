using System;
using Shouldly;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests
{
    public class CalendarTests
    {
        [Fact]
        public void Today_Return_DateTimeToday()
        {
            //arrange
            var sut = new Calendar();

            //act
            var result = sut.Today;

            //assert
            result.ShouldBe(DateTime.Today);
        }
    }
}
