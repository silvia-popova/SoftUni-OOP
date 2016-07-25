namespace InfernoInfinity.Core
{
    using System;

    public class GameException : Exception
    {
        public GameException(string msg)
            : base(msg)
        {
        }
    }
}
