using System.Collections.Generic;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ISupportEngineersFactory
    {
        IEnumerable<ISupportEngineer> GetSupportEngineers();
    }
}