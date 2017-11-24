using System.Collections.Generic;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Repository
{
    internal class SupportEngineersRepository : ISupportEngineersRepository
    {
        private readonly WheelOfFateContext _wheelOfFateContext;

        public SupportEngineersRepository(WheelOfFateContext wheelOfFateContext)
        {
            _wheelOfFateContext = wheelOfFateContext;
        }
        public IEnumerable<ISupportEngineer> GetEngineers()
        {
            return _wheelOfFateContext.SuportEngineers;
        }

        public void Save()
        {
            _wheelOfFateContext.SaveChanges();
        }
    }
}
