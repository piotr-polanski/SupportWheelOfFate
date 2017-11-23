using System;
using System.Linq;
using SupportWheelOfFate.Domain.Abstract;

namespace SupportWheelOfFate.Domain
{
    public class WheelOfFate
    {
        private readonly IEngineersRepository _engineersRepository;

        internal WheelOfFate(IEngineersRepository engineersRepository)
        {
            _engineersRepository = engineersRepository;
        }

        public BauShift SelectTodaysBauShift()
        {
            var avaliableEngineers = _engineersRepository.GetEngineers().ToList();

            Random random = new Random();

            var morningShifIndex = random.Next(1, avaliableEngineers.Count);
            var morningShiftEngineer = avaliableEngineers.ElementAt(morningShifIndex);
            avaliableEngineers.RemoveAt(morningShifIndex);

            var afterNoonShifIndex = random.Next(1, avaliableEngineers.Count);
            var afterNoonShiftEngineer = avaliableEngineers.ElementAt(afterNoonShifIndex);

            return new BauShift(morningShiftEngineer, afterNoonShiftEngineer);
        }
    }
}