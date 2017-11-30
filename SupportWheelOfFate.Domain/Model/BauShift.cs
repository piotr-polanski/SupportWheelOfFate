using System.Collections.Generic;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain.Model
{
    public class BauShift
    {
        public BauShift(IEnumerable<ISupportEngineer> shift)
        {
            Shift = shift;
        }

        public IEnumerable<ISupportEngineer> Shift { get; }
    }
}