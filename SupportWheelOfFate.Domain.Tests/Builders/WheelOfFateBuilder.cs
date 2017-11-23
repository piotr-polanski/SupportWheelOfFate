using System.Collections.Generic;
using FakeItEasy;
using Ploeh.AutoFixture;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class WheelOfFateBuilder
    {
        private IEnumerable<SupportEngineer> _supportEngineersFromRepo;
        private readonly Fixture _fixture;
        private IEnumerable<SupportEngineer> _supportEngineersAfterFilter;

        public WheelOfFateBuilder()
        {
            _fixture = new Fixture();
            _supportEngineersFromRepo = _fixture.CreateMany<SupportEngineer>(10);
            _supportEngineersAfterFilter = _fixture.CreateMany<SupportEngineer>(2);
        }

        public WheelOfFateBuilder WithEngineersFromRepo(IEnumerable<SupportEngineer> supportEngineers)
        {
            _supportEngineersFromRepo = supportEngineers;
            return this;
        }

        public WheelOfFateBuilder WithSupportEngineersFromFilter(IEnumerable<SupportEngineer> supportEngineers)
        {
            _supportEngineersAfterFilter = supportEngineers;
            return this;
        }
        public WheelOfFate Build()
        {
            var engineersRepository = A.Fake<ISupportEngineersRepository>();
            A.CallTo(() => engineersRepository.GetEngineers())
                .Returns(_supportEngineersFromRepo);

            var engineersFilterChain = A.Fake<ISupportEngineersFilterChain>();
            A.CallTo(() => engineersFilterChain.Filter(_supportEngineersFromRepo))
                .Returns(_supportEngineersAfterFilter);

            var filterChainFactory = A.Fake<IFilterChainFactory>();
            A.CallTo(() => filterChainFactory.Create())
                .Returns(engineersFilterChain);

            return new WheelOfFate(engineersRepository, filterChainFactory);
        }
    }
}