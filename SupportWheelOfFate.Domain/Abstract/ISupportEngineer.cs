using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ISupportEngineer
    {
        int Id { get;}
        string Name { get;}
        void LogTodaysShift();
        int ShiftCount { get; }
        IEnumerable<Shift> LastTwoShifts { get; } 
        bool DidntHadShiftYesterday();
        bool HadShiftYesterday();
        bool DidntHadTwoShiftInLastTwoWeeks();
        bool HadTwoShiftsInLastTwoWeeks();
        bool HaveShiftToday();
        bool DidntHadShiftInLastWeek();
    }
}