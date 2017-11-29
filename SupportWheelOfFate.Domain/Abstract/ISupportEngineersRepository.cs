using System.Collections.Generic;
using SupportWheelOfFate.Domain.Repository;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ISupportEngineersRepository
    {
        IEnumerable<SupportEngineerDto> GetEngineerDtos();
        void Save();
    }
}