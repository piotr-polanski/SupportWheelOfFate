using System;
using System.Collections.Generic;
using System.Linq;

namespace SupportWheelOfFate.Domain.Model
{
    public class SupportEngineer : ISupportEngineer
    {
        private const int FourteenDays = 14;

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
        public bool HadTwoShiftsInLastTwoWeeks()
        {
            if (DidntHadAnyShifts())
                return false;
            if (HaveMoreThanOneShift())
                return 
                    IsDateWithinTwoWeeks(ShiftLog.OrderByDescending(d => d).Skip(1).First()) 
                    && IsDateWithinTwoWeeks(ShiftLog.OrderByDescending(d => d).First());
            return false;
        }

        public bool DidntHadTwoShiftInLastTwoWeeks()
        {
            return !HadTwoShiftsInLastTwoWeeks();
        }

        private bool HaveMoreThanOneShift()
        {
            return ShiftLog.Count > 1;
        }

        private bool DidntHadAnyShifts()
        {
            return !ShiftLog.Any();
        }

        private bool IsDateWithinTwoWeeks(DateTime date)
        {
            return (DateTime.Today - date).TotalDays <= FourteenDays;
        }

    }
}