using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
{
    internal interface ISupportEngineersRepository
    {
        IEnumerable<SupportEngineer> GetEngineers();
    }
}