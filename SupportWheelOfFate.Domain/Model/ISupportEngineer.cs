using System;
using System.Collections.Generic;

namespace SupportWheelOfFate.Domain.Model
{
    public interface ISupportEngineer
    {
        int Id { get; set; }
        string Name { get; set; }
        ICollection<Shift> ShiftLog { get; }
        void LogTodaysShift();
        bool DidntHadShiftYesterday();
        bool HadShiftYesterday();
        bool DidntHadTwoShiftInLastTwoWeeks();
        bool HadTwoShiftsInLastTwoWeeks();
        bool HaveShiftToday();
    }
}