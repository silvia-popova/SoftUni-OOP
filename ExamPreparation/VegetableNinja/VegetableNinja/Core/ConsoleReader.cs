using System;
using VegetableNinja.Contracts;

namespace VegetableNinja.Core
{
    public class ConsoleReader : IInputReader
    {
        public string ReadNextLine()
        {
            return Console.ReadLine();
        }
    }
}
