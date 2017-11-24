namespace SupportWheelOfFate.Domain.Model
{
    public class BauShift
    {
        public BauShift(ISupportEngineer morningShiftEngineer, ISupportEngineer afterNoonShiftEngineer)
        {
            MorningShiftEngineer = morningShiftEngineer;
            AfterNoonShiftEngineer = afterNoonShiftEngineer;
        }

        public ISupportEngineer MorningShiftEngineer { get; }
        public ISupportEngineer AfterNoonShiftEngineer { get; }
    }
}