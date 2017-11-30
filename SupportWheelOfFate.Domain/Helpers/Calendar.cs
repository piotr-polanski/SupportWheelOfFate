using System;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.Helpers
{
    public class Calendar : ICalendar
    {
        private const int FourteenDays = 14;
        public DateTime Today => DateTime.Today;
        public DateTime Yesterday => DateTime.Today.AddDays(-1);
        public DateTime WeekAgo => DateTime.Today.AddDays(-7);
        public bool IsDateWhithinTwoWeeks(DateTime date) => (Today - date).TotalDays <= FourteenDays;
    }
}