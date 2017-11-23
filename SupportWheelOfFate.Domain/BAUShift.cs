using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain
{
    public class BAUShift
    {
        public BAUShift(SupportEngineer morningShiftEngineer, SupportEngineer afterNoonShiftEngineer)
        {
            MorningShiftEngineer = morningShiftEngineer;
            AfterNoonShiftEngineer = afterNoonShiftEngineer;
        }

        public SupportEngineer MorningShiftEngineer { get; }
        public SupportEngineer AfterNoonShiftEngineer { get; }
    }
}