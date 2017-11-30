using System.Collections.Generic;

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