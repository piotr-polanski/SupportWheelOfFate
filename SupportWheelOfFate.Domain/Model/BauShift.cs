namespace SupportWheelOfFate.Domain.Model
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