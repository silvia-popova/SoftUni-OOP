using VegetableNinja.Contracts;

namespace VegetableNinja.Models
{
    public class Player : IPlayer
    {
        private int power;
        private int stamina;
        private ICollisionHandler collisionHandler;

        public Player(int x, int y, string name)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Symbol = name[0];
            this.Power = 1;
            this.Stamina = 1;
            this.collisionHandler = new CollisionHandler(this);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; }

        public char Symbol { get; }

        public ICollisionHandler CollisionHandler => this.collisionHandler;

        public int Power
        {
            get
            {
                return this.power;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.stamina = value;
            }
        }

        //public event OnMelolemonmelonEatenEventHandler OnMelolemonmelonEaten;
    }
}
