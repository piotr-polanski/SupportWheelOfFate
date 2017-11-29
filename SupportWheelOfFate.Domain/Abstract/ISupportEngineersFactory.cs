using System.Collections.Generic;
using SupportWheelOfFate.Domain.Model;
using SupportWheelOfFate.Domain.Repository;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface ISupportEngineersFactory
    {
        IEnumerable<ISupportEngineer> CreteSupportEngineers();
    }
}