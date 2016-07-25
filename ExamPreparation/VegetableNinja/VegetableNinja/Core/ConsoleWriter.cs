using System;
using VegetableNinja.Contracts;

namespace VegetableNinja.Core
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string line)
        {
            Console.WriteLine(line);
        }
    }
}
