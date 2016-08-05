namespace LambdaCore.Exceptions
{
    using System;

    public class CurrentCoreNotSetException : Exception
    {
        public CurrentCoreNotSetException(string message)
            : base(message)
        {
        }
    }
}
