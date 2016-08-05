namespace Problem4.WorkForce.Core
{
    using System;
    using Problem4.WorkForce.Contracts;

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
                    throw new ArgumentNullException();
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
                    throw new ArgumentNullException();
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
                    throw new ArgumentNullException();
                }

                this.commandInterpreter = value;
            }
        }

        public void Run()
        {
            string input = this.reader.ReadLine();

            while (input != "End")
            {
                try
                {
                    var output = this.commandInterpreter.InterpretCommand(input);

                    if (output != null)
                    {
                        this.Writer.WriteLine(output);
                    }
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
