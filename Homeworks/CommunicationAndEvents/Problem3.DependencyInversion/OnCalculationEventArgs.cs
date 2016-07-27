using System;

namespace Problem3.DependencyInversion
{
    public class OnCalculationEventArgs : EventArgs
    {
        public OnCalculationEventArgs(int firstOperand, int secondOperand, char @operator)
        {
            this.FirstOperand = firstOperand;
            this.SecondOperand = secondOperand;
            this.Operator = @operator;
        }

        public int FirstOperand { get; }

        public int SecondOperand { get; }

        public int Operator { get; }
    }
}
