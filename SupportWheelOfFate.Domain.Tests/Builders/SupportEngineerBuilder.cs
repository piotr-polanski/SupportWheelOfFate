using System;
using SupportWheelOfFate.Domain.Model;
using System.Linq;
using System.Collections.Generic;
using FakeItEasy;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Infrastructure.Repository;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class SupportEngineerBuilder
    {
        private ICollection<Shift> shiftLog = new List<Shift>();
        private ICalendar _calendar = A.Fake<ICalendar>();

        public SupportEngineerBuilder()
        {
            A.CallTo(() => _calendar.Today).Returns(DateTime.Today);
        }

        public SupportEngineer Build()
        {
            var supportEngineer = new SupportEngineer(_calendar, new SupportEngineerDto("name", shiftLog));
            return supportEngineer;
        }

        public SupportEngineerBuilder WithShiftLoggedOnDate(DateTime shiftDate)
        {
            if(shiftDate != default(DateTime))
                shiftLog.Add(new Shift() { Date = shiftDate });
            return this;
        }

        public SupportEngineerBuilder WihtDateProvider(ICalendar calendar)
        {
            _calendar = calendar;
            return this;
        }
    }
}
