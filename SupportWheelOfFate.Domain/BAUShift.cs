using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain
{
    public class BauShift
    {
        public BauShift(SupportEngineer morningShiftEngineer, SupportEngineer afterNoonShiftEngineer)
        {
            MorningShiftEngineer = morningShiftEngineer;
            AfterNoonShiftEngineer = afterNoonShiftEngineer;
        }

        public SupportEngineer MorningShiftEngineer { get; }
        public SupportEngineer AfterNoonShiftEngineer { get; }
    }
}