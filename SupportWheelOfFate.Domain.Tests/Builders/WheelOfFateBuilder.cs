using System.Collections.Generic;
using FakeItEasy;
using Ploeh.AutoFixture;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class WheelOfFateBuilder
    {
        private IEnumerable<SupportEngineer> _supportEngineers;
        private Fixture _fixture;

        public WheelOfFateBuilder()
        {
            _fixture = new Fixture();
            _supportEngineers = _fixture.CreateMany<SupportEngineer>(10);
        }

        public WheelOfFateBuilder With(IEnumerable<SupportEngineer> supportEngineers)
        {
            _supportEngineers = supportEngineers;
            return this;
        }
        public WheelOfFate Build()
        {
            var engineersRepository = A.Fake<IEngineersRepository>();
            A.CallTo(() => engineersRepository.GetEngineers())
                .Returns(_supportEngineers);
            return new WheelOfFate(engineersRepository);
        }
    }
}