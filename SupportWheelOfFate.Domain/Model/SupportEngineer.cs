using System;
using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Repository;

namespace SupportWheelOfFate.Domain.Model
{
    public class SupportEngineer : ISupportEngineer
    {
        private readonly ICalendar _calendar;
        private readonly SupportEngineerDto _state;
        private const int FourteenDays = 14;

        internal SupportEngineer(ICalendar calendar, SupportEngineerDto state)
        {
            this._calendar = calendar;
            _state = state;
        }

        public int Id => _state.Id;
        public string Name => _state.Name;
        public ICollection<Shift> ShiftLog => _state.ShiftLog;

        public void LogTodaysShift()
        {
            ShiftLog.Add(new Shift() { Date = _calendar.Today});
        }

        public bool DidntHadShiftYesterday()
        {
            return !HadShiftYesterday();
        }

        public bool HadShiftYesterday()
        {
            if (DidntHadAnyShifts())
                return false;
            return (_calendar.Today.AddDays(-1) == ShiftLog.OrderByDescending(d => d.Date).First().Date);
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
                return ShiftLog.OrderByDescending(d => d.Date).First().Date == _calendar.Today;
            return false;
        }

        public bool DidntHadShiftInLastWeek()
        {
            if (DidntHadAnyShifts())
                return true;
            return ShiftLog.OrderByDescending(d => d.Date).First().Date < _calendar.Today.AddDays(-7);
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
            return (_calendar.Today - date).TotalDays <= FourteenDays;
        }

    }
}