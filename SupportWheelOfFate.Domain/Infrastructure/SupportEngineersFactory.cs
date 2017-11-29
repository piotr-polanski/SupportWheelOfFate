using System.Collections.Generic;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.Repository;

namespace SupportWheelOfFate.Domain.Infrastructure
{
    internal class SupportEngineersFactory : ISupportEngineersFactory
    {
        private readonly ISupportEngineersRepository _supportEngineersRepository;
        private readonly ICalendar _calendar;

        public SupportEngineersFactory(ISupportEngineersRepository supportEngineersRepository, ICalendar calendar)
        {
            _supportEngineersRepository = supportEngineersRepository;
            _calendar = calendar;
        }
        public IEnumerable<ISupportEngineer> CreteSupportEngineers(IEnumerable<SupportEngineerDto> engineerDtos)
        {
            return engineerDtos.Select(dto => new SupportEngineer(_calendar, dto));
        }
    }
}