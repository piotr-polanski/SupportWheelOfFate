using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
{
    internal interface IEngineersRepository
    {
        IEnumerable<SupportEngineer> GetEngineers();
    }
}