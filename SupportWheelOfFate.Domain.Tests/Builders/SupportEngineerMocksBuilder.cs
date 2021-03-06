﻿using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class SupportEngineerMocksBuilder
    {
        private IList<ISupportEngineer> engineersWhoDidntHadShiftYesterday;
        private IList<ISupportEngineer> engineersWhoHadShiftYesterday;
        private IList<ISupportEngineer> engineersWhoDintHadTwoShiftInLastTwoWeeks;
        private IList<ISupportEngineer> engineersWhoHadTwoShiftInLastTwoWeeks;
        private IList<ISupportEngineer> engineersWhoWereAlreadySelectedToday;
        private IList<ISupportEngineer> engineersWhoDidntHadShiftInLastWeek;
        private IList<ISupportEngineer> engineersWhoHadShiftInLastWeek;

        public SupportEngineerMocksBuilder()
        {
            engineersWhoDidntHadShiftYesterday = new List<ISupportEngineer>();
            engineersWhoHadShiftYesterday = new List<ISupportEngineer>();
            engineersWhoDintHadTwoShiftInLastTwoWeeks = new List<ISupportEngineer>();
            engineersWhoHadTwoShiftInLastTwoWeeks = new List<ISupportEngineer>();
            engineersWhoWereAlreadySelectedToday = new List<ISupportEngineer>();
            engineersWhoDidntHadShiftInLastWeek = new List<ISupportEngineer>();
            engineersWhoHadShiftInLastWeek = new List<ISupportEngineer>();
        }

        public IEnumerable<ISupportEngineer> Build()
        {
            return engineersWhoDidntHadShiftYesterday
                .Concat(engineersWhoHadShiftYesterday)
                .Concat(engineersWhoDintHadTwoShiftInLastTwoWeeks)
                .Concat(engineersWhoHadTwoShiftInLastTwoWeeks)
                .Concat(engineersWhoWereAlreadySelectedToday)
                .Concat(engineersWhoDidntHadShiftInLastWeek)
                .Concat(engineersWhoHadShiftInLastWeek);
        }

        public SupportEngineerMocksBuilder WithEngineersWhoDidntHadShiftYesterday(int engineersNumber)
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
        public SupportEngineerMocksBuilder WihtEngineersWhoDidntHadTwoShiftInLastTwoWeeks(int engineersNumber)
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
        public SupportEngineerMocksBuilder WihtEngineersWhoHadTwoShiftInLastTwoWeeks(int engineersNumber)
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

        public SupportEngineerMocksBuilder WithEngineersWhoHadShiftYesterday(int engineersNumber)
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
        public SupportEngineerMocksBuilder WithEngineersAlreadySelectedForToday(int engineersNumber)
        {
            for (int i = 0; i < engineersNumber; i++)
            {
                var engineerWhoWereAlreadySelectedToday = A.Fake<ISupportEngineer>();
                A.CallTo(() => engineerWhoWereAlreadySelectedToday.HaveShiftToday())
                    .Returns(true);
                A.CallTo(() => engineerWhoWereAlreadySelectedToday.Name)
                    .Returns(nameof(WithEngineersAlreadySelectedForToday));
                engineersWhoWereAlreadySelectedToday.Add(engineerWhoWereAlreadySelectedToday);
            }
            return this;
        }

        public SupportEngineerMocksBuilder WithEngineersWhoDidntHadShiftInLastWeek(int engineersNumber)
        {
            for (int i = 0; i < engineersNumber; i++)
            {
                var engineerWhoDidntHadShiftInLastWeek = A.Fake<ISupportEngineer>();
                A.CallTo(() => engineerWhoDidntHadShiftInLastWeek.DidntHadShiftInLastWeek())
                    .Returns(true);
                A.CallTo(() => engineerWhoDidntHadShiftInLastWeek.Name)
                    .Returns(nameof(WithEngineersWhoDidntHadShiftInLastWeek));
                engineersWhoDidntHadShiftInLastWeek.Add(engineerWhoDidntHadShiftInLastWeek);
            }
            return this;
        }

        public SupportEngineerMocksBuilder WihtEngineersWhoHadShiftInLastWeeks(int engineersNumber)
        {
            for (int i = 0; i < engineersNumber; i++)
            {
                var engineerWhoHadShiftInLastWeek = A.Fake<ISupportEngineer>();
                A.CallTo(() => engineerWhoHadShiftInLastWeek.DidntHadShiftInLastWeek())
                    .Returns(false);
                A.CallTo(() => engineerWhoHadShiftInLastWeek.Name)
                    .Returns(nameof(WithEngineersWhoDidntHadShiftInLastWeek));
                engineersWhoHadShiftInLastWeek.Add(engineerWhoHadShiftInLastWeek);
            }
            return this;
        }
    }
}
