using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ISupportEngineersRepository
    {
        IEnumerable<ISupportEngineer> GetEngineers();
        void Save();
    }
}