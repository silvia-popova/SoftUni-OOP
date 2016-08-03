namespace LambdaCore.Core
{
    using System;
    using LambdaCore.Contracts;

    public class Engine : IEngine
    {
        private IInpuReader reader;
        private IOutputWriter writer;
        private ICommandInterpreter commandInterpreter;
        private IPowerPlant powerPlant;
        private bool isRunning;

        public Engine(
            IInpuReader reader, 
            IOutputWriter writer, 
            ICommandInterpreter commandInterpreter, 
            IPowerPlant powerPlant)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.commandInterpreter = commandInterpreter;
            this.commandInterpreter.Engine = this;
            this.PowerPlant = powerPlant;
        }

        public IInpuReader Reader
        {
            get
            {
                return reader;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                reader = value;
            }
        }

        public IOutputWriter Writer
        {
            get
            {
                return writer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                writer = value;
            }
        }

        public IPowerPlant PowerPlant { get; private set; }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string input = this.reader.ReadLine();

                this.commandInterpreter.InterpretCommand(input);
            }
        }
    }
}
