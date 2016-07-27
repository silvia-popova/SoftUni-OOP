namespace Problem3.DependencyInversion
{
    public delegate void OnCalculationEventHandler(PrimitiveCalculator sender, OnCalculationEventArgs eventArgs);

    public class PrimitiveCalculator
    {
        public event OnCalculationEventHandler OnCalculation;
        
        private char @operator;

        public PrimitiveCalculator(CalculationStrategy calculationStrategy)
        {
            this.@operator = '+';
            this.OnCalculation += calculationStrategy.Calculate;
        }

        public void ChangeStrategy(char @operator)
        {
            this.@operator = @operator;
        }

        public void PerformCalculation(int firstOperand, int secondOperand)
        {
              this.OnCalculation?.Invoke(
                  this, 
                  new OnCalculationEventArgs(firstOperand, secondOperand, this.@operator));            
        }
    }
}
