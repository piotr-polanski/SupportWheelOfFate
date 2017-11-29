using System;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ICalendar
    {
        DateTime Today { get; }
    }
}