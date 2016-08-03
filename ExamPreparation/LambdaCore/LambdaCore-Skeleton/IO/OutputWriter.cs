namespace LambdaCore.IO
{
    using System;
    using LambdaCore.Contracts;

    public class OutputWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
