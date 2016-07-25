using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableNinja.Models
{
    public class Melolemonmelon : Vegetable
    {
        private bool IsCollected;

        public Melolemonmelon(int x, int y) 
            : base(x, y, "Melolemonmelon", '*', 0, 0, 0)
        {
        }

        public override void Grow()
        {
            base.Grow();
        }
    }
}
