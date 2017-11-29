using System;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain
{
    public class Calendar : ICalendar
    {
        public DateTime Today => DateTime.Today;
    }
}