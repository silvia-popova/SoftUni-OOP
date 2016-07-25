namespace VegetableNinja.Models
{
    public class Mushroom : Vegetable
    {
        public Mushroom(int x, int y)
            : base(x, y, "Mushroom", 'M', -10, -10, 5)
        {
        }
    }
}
