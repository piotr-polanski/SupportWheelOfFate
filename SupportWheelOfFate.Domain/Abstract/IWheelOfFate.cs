using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Abstract
{
    public interface IWheelOfFate
    {
        BauShift SelectTodaysBauShift();
    }
}