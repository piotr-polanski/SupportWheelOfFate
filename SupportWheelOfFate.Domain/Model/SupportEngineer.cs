using System;
using System.Collections.Generic;
using System.Linq;

namespace SupportWheelOfFate.Domain.Model
{
    public class SupportEngineer : ISupportEngineer
    {
        private const int FourteenDays = 14;

        internal SupportEngineer()
        {
        }

        internal SupportEngineer(string name, IList<Shift> shiftLog)
        {
            Name = name;
            ShiftLog = shiftLog;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Shift> ShiftLog { get; set; }

        public void LogTodaysShift()
        {
            ShiftLog.Add(new Shift() { Date = DateTime.Today });
        }

        public bool DidntHadShiftYesterday()
        {
            if (!ShiftLog.Any())
                return true;
            return (DateTime.Today - ShiftLog.OrderByDescending(d => d.Date).First().Date).TotalDays > 1;
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
                    IsDateWithinTwoWeeks(ShiftLog.OrderByDescending(d => d.Date).Skip(1).First().Date) 
                    && IsDateWithinTwoWeeks(ShiftLog.OrderByDescending(d => d.Date).First().Date);
            return false;
        }

        public bool HaveShiftToday()
        {
            if (ShiftLog.Any())
                return ShiftLog.OrderByDescending(d => d.Date).First().Date == DateTime.Today;
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