using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain
{
    public class WheelOfFate
    {
        public BAUShift SelectTodaysBAUShift()
        {
            return new BAUShift(new SupportEngineer(), new SupportEngineer());
        }
    }
}