namespace Problem4.WorkForce.IO
{
    using System;
    using Problem4.WorkForce.Contracts;

    public class InpuReader : IInpuReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
