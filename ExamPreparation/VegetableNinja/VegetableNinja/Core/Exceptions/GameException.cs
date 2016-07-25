using System;

namespace VegetableNinja.Core.Exceptions
{
    public class GameException : Exception
    {
        public GameException(string msg)
            : base(msg)
        {
        }
    }
}
