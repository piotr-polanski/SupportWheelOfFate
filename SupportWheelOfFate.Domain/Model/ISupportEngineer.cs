using System;
using System.Collections.Generic;

namespace SupportWheelOfFate.Domain.Model
{
    public interface ISupportEngineer
    {
        int Id { get;}
        string Name { get;}
        ICollection<Shift> ShiftLog { get; }
        void LogTodaysShift();
        bool DidntHadShiftYesterday();
        bool HadShiftYesterday();
        bool DidntHadTwoShiftInLastTwoWeeks();
        bool HadTwoShiftsInLastTwoWeeks();
        bool HaveShiftToday();
        bool DidntHadShiftInLastWeek();
    }
}