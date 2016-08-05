namespace LambdaCore
{
    using LambdaCore.Contracts;
    using LambdaCore.Core;
    using LambdaCore.IO;

    public class StartUp
    {
        public static void Main()
        {
            IInpuReader reader = new InpuReader();
            IOutputWriter writer = new OutputWriter();
            ICommandFactory commandFactory= new CommandFactory();
            IPowerPlant powerPlant = new PowerPlant();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(commandFactory, powerPlant);

            IEngine engine = new Engine(reader, writer, commandInterpreter);
            engine.Run();
        }
    }
}
