using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain
{
    public interface IWheelOfFate
    {
        BauShift SelectTodaysBauShift();
    }
}