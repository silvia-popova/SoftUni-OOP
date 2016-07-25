namespace InfernoInfinity.Core
{
    using System;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly IGameController controler;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(IGameController controler, IInputReader reader, IOutputWriter writer)
        {
            this.controler = controler;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();

            while (input != "END")
            {
                try
                {
                    this.controler.ExecuteCommand(input);
                }
                catch (GameException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

                input = this.reader.ReadLine();
            }
        }
    }
}
