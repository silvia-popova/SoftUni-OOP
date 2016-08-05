namespace LambdaCore.Core
{
    using System;
    using LambdaCore.Contracts;
    using LambdaCore.IO;

    public class Engine : IEngine
    {
        private IInpuReader reader;
        private IOutputWriter writer;
        private ICommandInterpreter commandInterpreter;

        public Engine(
            IInpuReader reader, 
            IOutputWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.CommandInterpreter = commandInterpreter;
        }

        protected IInpuReader Reader
        {
            get
            {
                return this.reader;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format(Messages.NullParameter, nameof(this.reader)));
                }

                this.reader = value;
            }
        }

        protected IOutputWriter Writer
        {
            get { return this.writer; }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format(Messages.NullParameter, nameof(this.writer)));

                }

                this.writer = value;
            }
        }

        protected ICommandInterpreter CommandInterpreter
        {
            get
            {
                return this.commandInterpreter;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format(Messages.NullParameter, nameof(this.commandInterpreter)));

                }

                this.commandInterpreter = value;
            }
        }

        public void Run()
        {
            string input = this.reader.ReadLine();

            while (input != "System Shutdown!")
            {
                try
                {
                    this.Writer.WriteLine(this.commandInterpreter.InterpretCommand(input));
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }

                input = this.reader.ReadLine();
            }
        }
    }
}
