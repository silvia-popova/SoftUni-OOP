using System;
using InfernoInfinity.Contracts;

namespace InfernoInfinity.IO
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
