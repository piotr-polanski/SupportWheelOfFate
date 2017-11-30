using System;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ICalendar
    {
        DateTime Today { get; }
        DateTime Yesterday { get; }
        DateTime WeekAgo { get; }
    }
}