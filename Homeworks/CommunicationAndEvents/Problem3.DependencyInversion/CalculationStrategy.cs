namespace Problem3.DependencyInversion
{
    using System;

    public class CalculationStrategy
    {
        public void Calculate(PrimitiveCalculator sender, OnCalculationEventArgs eventArgs)
        {
            switch (eventArgs.Operator)
            {
                case '+':
                    Console.WriteLine(eventArgs.FirstOperand + eventArgs.SecondOperand);
                    break;
                case '-':
                    Console.WriteLine(eventArgs.FirstOperand - eventArgs.SecondOperand);
                    break;
                case '*':
                    Console.WriteLine(eventArgs.FirstOperand * eventArgs.SecondOperand);
                    break;
                case '/':
                    Console.WriteLine(eventArgs.FirstOperand / eventArgs.SecondOperand);
                    break;
                default:
                    throw new InvalidOperationException("Unknown mode");
            }
        }
    }
}
