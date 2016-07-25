using VegetableNinja.Contracts;

namespace VegetableNinja.Models
{
    public abstract class Vegetable : IVegetable
    {
        private int growingCounter;

        protected Vegetable(int x, 
            int y, 
            string name, 
            char symbol, 
            int powerPoints, 
            int staminaPoints, 
            int growingTime)
        {
            X = x;
            Y = y;
            Name = name;
            Symbol = symbol;
            PowerPoints = powerPoints;
            StaminaPoints = staminaPoints;
            GrowingTime = growingTime;
            //this.growingCounter = -1;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; }
        public char Symbol { get; }
        public int PowerPoints { get; set; }
        public int StaminaPoints { get; set; }
        public int GrowingTime { get; set; }

        public bool IsGrowing { get; set; }

        public bool IsSteppedOn { get; set; }

        public virtual void Grow()
        {
            if (IsGrowing && !IsSteppedOn)
            {
                this.growingCounter++;

                if (this.growingCounter == GrowingTime)
                {
                    this.IsGrowing = false;

                    this.growingCounter = 0;
                }
            }
        }
    }
}
