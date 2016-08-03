namespace LambdaCore.IO
{
    using System;
    using LambdaCore.Contracts;

    public class InpuReader : IInpuReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
