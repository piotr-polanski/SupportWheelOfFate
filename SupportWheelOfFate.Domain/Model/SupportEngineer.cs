using System;
using System.Collections.Generic;
using System.Linq;

namespace SupportWheelOfFate.Domain.Model
{
    public class SupportEngineer : ISupportEngineer
    {

        public SupportEngineer()
        {
            ShiftLog = new List<DateTime>();
        }
        public string Name { get; set; }
        public IList<DateTime> ShiftLog { get; }

        public void LogTodaysShift()
        {
            ShiftLog.Add(DateTime.Today);
        }

        public bool DidntHadShiftYesterday()
        {
            if (!ShiftLog.Any())
                return true;
            return (DateTime.Today - ShiftLog.OrderByDescending(d => d).First()).TotalDays > 1;
        }

        public bool HadShiftYesterday()
        {
            return !DidntHadShiftYesterday();
        }
    }
}