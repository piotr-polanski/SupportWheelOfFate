using System;
using SupportWheelOfFate.Domain.Model;
using System.Linq;
using System.Collections.Generic;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class SupportEngineerBuilder
    {
        private ICollection<Shift> shiftLog = new List<Shift>();

        public SupportEngineer Build()
        {
            var supportEngineer = new SupportEngineer();
            supportEngineer.ShiftLog = shiftLog;
            return supportEngineer;
        }

        public SupportEngineerBuilder WithShiftLoggedFromNow(int daysToAdd)
        {
            shiftLog.Add(new Shift() { Date = DateTime.Today.AddDays(daysToAdd) });
            return this;
        }

        internal SupportEngineerBuilder WithShiftLoggedOnDate(DateTime shiftDate)
        {
            if(shiftDate != default(DateTime))
                shiftLog.Add(new Shift() { Date = shiftDate });
            return this;
        }
    }
}
