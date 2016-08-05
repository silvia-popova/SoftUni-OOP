namespace Problem4.WorkForce
{
    using Problem4.WorkForce.Contracts;
    using Problem4.WorkForce.Core;
    using Problem4.WorkForce.IO;

    class StartUp
    {
        static void Main(string[] args)
        {
            IInpuReader reader = new InpuReader();
            IOutputWriter writer = new OutputWriter();
            ICommandFactory commandFactory = new CommandFactory();
            IData data = new Data();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(commandFactory, data);

            IEngine engine = new Engine(reader, writer, commandInterpreter);
            engine.Run();
        }
    }
}
