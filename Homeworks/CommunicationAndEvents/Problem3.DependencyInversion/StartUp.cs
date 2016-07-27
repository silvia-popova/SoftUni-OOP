namespace Problem3.DependencyInversion
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var calcStrategy = new CalculationStrategy();
            var calculator = new PrimitiveCalculator(calcStrategy);

            string line = Console.ReadLine();

            while (line != "End")
            {
                var commandArgs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];

                if (command == "mode")
                {
                    calculator.ChangeStrategy(commandArgs[1][0]);
                }
                else
                {
                    calculator.PerformCalculation(int.Parse(commandArgs[0]), int.Parse(commandArgs[1]));
                }

                line = Console.ReadLine();
            }
        }
    }
}
