using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

    public class SupportEngineerDto
    {
        public SupportEngineerDto()
        {
            
        }
        public SupportEngineerDto(string name, ICollection<Shift> shiftLog)
        {
            Name = name;
            ShiftLog = shiftLog;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Shift> ShiftLog { get; set; }
    }
}
