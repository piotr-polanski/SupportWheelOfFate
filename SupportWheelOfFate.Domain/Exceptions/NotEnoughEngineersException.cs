using System;

namespace SupportWheelOfFate.Domain.Exceptions
{
    public class NotEnoughEngineersException : Exception
    {
        public NotEnoughEngineersException()
        {
        }

        public NotEnoughEngineersException(string message): base(message)
        {
        }
    }
}