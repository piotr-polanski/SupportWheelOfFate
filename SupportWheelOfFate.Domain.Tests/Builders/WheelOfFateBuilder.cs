using System.Collections.Generic;
using FakeItEasy;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.FilterChainFactories;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class WheelOfFateBuilder
    {
        private IEnumerable<ISupportEngineer> _supportEngineersFromRepo;
        private IEnumerable<ISupportEngineer> _supportEngineersAfterFilter;

        public WheelOfFateBuilder()
        {
            _supportEngineersFromRepo = new SupportEngineerListBuilder()
                .WithEngineersWhoHadShiftYesterday(5)
                .Build();
            _supportEngineersAfterFilter = new SupportEngineerListBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(5)
                .Build();
        }

        public WheelOfFateBuilder WithEngineersFromRepo(IEnumerable<ISupportEngineer> supportEngineers)
        {
            _supportEngineersFromRepo = supportEngineers;
            return this;
        }

        public WheelOfFateBuilder WithSupportEngineersFromFilter(IEnumerable<ISupportEngineer> supportEngineers)
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