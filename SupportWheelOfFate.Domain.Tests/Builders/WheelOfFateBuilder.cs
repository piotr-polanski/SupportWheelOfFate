using System.Collections;
using System.Collections.Generic;
using FakeItEasy;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Tests.Builders
{
    public class WheelOfFateBuilder
    {
        private IEnumerable<ISupportEngineer> _supportEngineersFromRepo;
        private IEnumerable<ISupportEngineer> _supportEngineersAfterFilter;
        private ISupportEngineersFactory _supportEngineersFactory;
        private readonly ISupportEngineerFilterChainFactory _supportEngineerFilterChainFactory;
        private ISupportEngineersRepository _supportEngineersRepository;

        public WheelOfFateBuilder()
        {
            _supportEngineersRepository = A.Fake<ISupportEngineersRepository>();
            _supportEngineersFactory = A.Fake<ISupportEngineersFactory>();
            _supportEngineersFromRepo = new SupportEngineerMocksBuilder()
                .WithEngineersWhoHadShiftYesterday(5)
                .Build();
            _supportEngineersAfterFilter = new SupportEngineerMocksBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(5)
                .Build();
            _supportEngineerFilterChainFactory = A.Fake<ISupportEngineerFilterChainFactory>();
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

        public WheelOfFateBuilder WihtSupportEngineersFactory(ISupportEngineersFactory supportEngineersRepository)
        {
            _supportEngineersFactory = supportEngineersRepository;
            return this;
        }

        public WheelOfFate Build()
        {
            A.CallTo(() => _supportEngineersFactory.CreteSupportEngineers())
                .Returns(_supportEngineersFromRepo);

            var engineersFilterChain = A.Fake<ISupportEngineersFilterChain>();
            A.CallTo(() => engineersFilterChain.Filter(_supportEngineersFromRepo))
                .Returns(_supportEngineersAfterFilter);

            A.CallTo(() => _supportEngineerFilterChainFactory.Create())
                .Returns(engineersFilterChain);

            return new WheelOfFate(_supportEngineersRepository, _supportEngineersFactory, _supportEngineerFilterChainFactory);
        }

        public WheelOfFateBuilder WithSupportEngineersRepository(ISupportEngineersRepository supportEngineersRepository)
        {
            _supportEngineersRepository = supportEngineersRepository;
            return this;
        }
    }
}