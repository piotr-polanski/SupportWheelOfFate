using System;
using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Infrastructure.Repository;

namespace SupportWheelOfFate.Domain.Model
{
    public class SupportEngineer : ISupportEngineer
    {
        private readonly ICalendar _calendar;
        private readonly SupportEngineerDto _state;
        private const int FourteenDays = 14;

        internal SupportEngineer(ICalendar calendar, SupportEngineerDto state)
        {
            _calendar = calendar;
            _state = state;
        }

        public int Id => _state.Id;

        public string Name => _state.Name;

        public int ShiftCount => _state.ShiftLog.OrderByDescending(d => d.Date).Count();

        public IEnumerable<Shift> LastTwoShifts => _state.ShiftLog.OrderByDescending(d => d.Date).Take(2).ToList();

        public void LogTodaysShift()
        {
            _state.ShiftLog.Add(new Shift() { Date = _calendar.Today});
        }

        public bool DidntHadShiftYesterday()
        {
            return !HadShiftYesterday();
        }

        public bool HadShiftYesterday()
        {
            if (DidntHadAnyShifts())
                return false;

            return _calendar.Yesterday == NewestShift().Date;
        }

        public bool HadTwoShiftsInLastTwoWeeks()
        {
            if (DidntHadAnyShifts())
                return false;

            if (HaveMoreThanOneShift())
                return IsDateWithinTwoWeeks(SecondNewestShift().Date) 
                    && IsDateWithinTwoWeeks(NewestShift().Date);

            return false;
        }

        public bool HaveShiftToday()
        {
            if (_state.ShiftLog.Any())
                return NewestShift().Date == _calendar.Today;

            return false;
        }

        public bool DidntHadShiftInLastWeek()
        {
            if (DidntHadAnyShifts())
                return true;

            return NewestShift().Date < _calendar.WeekAgo;
        }

        public bool DidntHadTwoShiftInLastTwoWeeks()
        {
            return !HadTwoShiftsInLastTwoWeeks();
        }

        private bool HaveMoreThanOneShift()
        {
            return _state.ShiftLog.Count > 1;
        }

        private Shift SecondNewestShift()
        {
            return _state.ShiftLog.OrderByDescending(d => d.Date).Skip(1).First();
        }

        private bool DidntHadAnyShifts()
        {
            return !_state.ShiftLog.Any();
        }

        private bool IsDateWithinTwoWeeks(DateTime date)
        {
            return (_calendar.Today - date).TotalDays <= FourteenDays;
        }

        private Shift NewestShift()
        {
            return _state.ShiftLog.OrderByDescending(d => d.Date).First();
        }
    }
}