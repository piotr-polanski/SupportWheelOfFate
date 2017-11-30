using System;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.Infrastructure
{
    public class Calendar : ICalendar
    {
        public DateTime Today => DateTime.Today;
    }
}