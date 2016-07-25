namespace Game.IO
{
    using System;
    using Interfaces;

    public class ConsoleInputHandler : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
