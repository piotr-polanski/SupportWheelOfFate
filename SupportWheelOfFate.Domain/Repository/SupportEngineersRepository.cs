using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.Repository
{
    internal class SupportEngineersRepository : ISupportEngineersRepository
    {
        private readonly WheelOfFateContext _wheelOfFateContext;

        public SupportEngineersRepository(WheelOfFateContext wheelOfFateContext)
        {
            _wheelOfFateContext = wheelOfFateContext;
        }
        public IEnumerable<SupportEngineerDto> GetEngineerDtos()
        {
            return _wheelOfFateContext.SuportEngineers
                .Include(e => e.ShiftLog)
                .ToList();
        }

        public void Save()
        {
            _wheelOfFateContext.SaveChanges();
        }
    }
}
