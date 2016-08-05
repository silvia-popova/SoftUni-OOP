namespace LambdaCore.Exceptions
{
    using System;

    public class UnknownCommandException : Exception
    {
        private const string UnknownCommandMessage = "Unknown command.";

        public UnknownCommandException()
            : base(UnknownCommandMessage)
        {
        }
    }
}
