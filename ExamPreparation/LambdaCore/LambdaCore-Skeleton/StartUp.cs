namespace LambdaCore
{
    using LambdaCore.Contracts;
    using LambdaCore.Core;
    using LambdaCore.IO;
    using LambdaCore.IO.Commands;

    public class StartUp
    {
        public static void Main()
        {
            IInpuReader reader = new InpuReader();
            IOutputWriter writer = new OutputWriter();
            ICommandFactory commandFactory= new CommandFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(commandFactory);
            IPowerPlant powerPlant = new PowerPlant();

            IEngine engine = new Engine(reader, writer, commandInterpreter, powerPlant);
            engine.Run();
        }
    }
}
