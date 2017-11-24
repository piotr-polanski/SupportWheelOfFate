using System;
using System.Collections.Generic;

namespace SupportWheelOfFate.Domain.Model
{
    public interface ISupportEngineer
    {
        string Name { get; set; }
        IList<DateTime> ShiftLog { get; }
        void LogTodaysShift();
        bool DidntHadShiftYesterday();
        bool HadShiftYesterday();
    }
}