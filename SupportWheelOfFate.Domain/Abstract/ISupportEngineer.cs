using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
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