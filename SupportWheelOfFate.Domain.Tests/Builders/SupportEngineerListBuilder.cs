using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Ploeh.AutoFixture;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class SupportEngineerListBuilder
    {
        private IList<ISupportEngineer> engineersWhoDidntHadShiftYesterday;
        private IList<ISupportEngineer> engineersWhoHadShiftYesterday;
        private IList<ISupportEngineer> engineersWhoDintHadTwoShiftInLastTwoWeeks;
        private IList<ISupportEngineer> engineersWhoHadTwoShiftInLastTwoWeeks;

        public SupportEngineerListBuilder()
        {
            engineersWhoDidntHadShiftYesterday = new List<ISupportEngineer>();
            engineersWhoHadShiftYesterday = new List<ISupportEngineer>();
            engineersWhoDintHadTwoShiftInLastTwoWeeks = new List<ISupportEngineer>();
            engineersWhoHadTwoShiftInLastTwoWeeks = new List<ISupportEngineer>();
        }

        public SupportEngineerListBuilder WithEngineersWhoDidntHadShiftYesterday(int engineersNumber)
        {
            for (int i = 0; i < engineersNumber; i++)
            {
                var engineerWhoDidntHadShiftYesterday = A.Fake<ISupportEngineer>();
                A.CallTo(() => engineerWhoDidntHadShiftYesterday.DidntHadShiftYesterday())
                    .Returns(true);
                engineersWhoDidntHadShiftYesterday.Add(engineerWhoDidntHadShiftYesterday);
            }
            return this;
        }
        public SupportEngineerListBuilder WihtEngineersWhoDidntHadTwoShiftInLastTwoWeeks(int engineersNumber)
        {
            for (int i = 0; i < engineersNumber; i++)
            {
                var engineerWhoDidntHadShiftInLastTwoWeeks = A.Fake<ISupportEngineer>();
                A.CallTo(() => engineerWhoDidntHadShiftInLastTwoWeeks.DidntHadTwoShiftInLastTwoWeeks())
                    .Returns(true);
                engineersWhoDintHadTwoShiftInLastTwoWeeks.Add(engineerWhoDidntHadShiftInLastTwoWeeks);
            }
            return this;
        }
        public SupportEngineerListBuilder WihtEngineersWhoHadTwoShiftInLastTwoWeeks(int engineersNumber)
        {
            for (int i = 0; i < engineersNumber; i++)
            {
                var engineerWhoHadShiftInLastTwoWeeks = A.Fake<ISupportEngineer>();
                A.CallTo(() => engineerWhoHadShiftInLastTwoWeeks.HadTwoShiftsInLastTwoWeeks())
                    .Returns(true);
                engineersWhoHadTwoShiftInLastTwoWeeks.Add(engineerWhoHadShiftInLastTwoWeeks);
            }
            return this;
        }

        public SupportEngineerListBuilder WithEngineersWhoHadShiftYesterday(int engineersNumber)
        {

            for (int i = 0; i < engineersNumber; i++)
            {
                var engineerWhoHadShiftYesterday = A.Fake<ISupportEngineer>();
                A.CallTo(() => engineerWhoHadShiftYesterday.HadShiftYesterday())
                    .Returns(true);
                engineersWhoHadShiftYesterday.Add(engineerWhoHadShiftYesterday);
            }
            return this;
        }

        public IEnumerable<ISupportEngineer> Build()
        {
            return engineersWhoDidntHadShiftYesterday
                .Concat(engineersWhoHadShiftYesterday)
                .Concat(engineersWhoDintHadTwoShiftInLastTwoWeeks)
                .Concat(engineersWhoHadTwoShiftInLastTwoWeeks);
        }

    }
}
