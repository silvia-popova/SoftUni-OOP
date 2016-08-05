namespace Problem4.WorkForce.IO
{
    using System;
    using Problem4.WorkForce.Contracts;

    public class OutputWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
