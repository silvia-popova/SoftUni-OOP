using System;
using InfernoInfinity.Contracts;

namespace InfernoInfinity.IO
{
    public class InputReader : IInputReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}
