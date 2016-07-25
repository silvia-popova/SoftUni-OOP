using VegetableNinja.Contracts;

namespace VegetableNinja.Models
{
    public class BlankSpace : Vegetable
    {
        public BlankSpace(int x, int y) 
            : base(x, y, "BlankSpace", '-', 0, 0, 0)
        {
        }
    }
}
