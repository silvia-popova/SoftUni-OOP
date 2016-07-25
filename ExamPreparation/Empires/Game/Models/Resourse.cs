using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game.Models
{
    public class Resourse : IResourse
    {
        private int quantity;
        private ResourseType resourseType;

        public Resourse(int quantity, ResourseType resourseType)
        {
            this.Quantity = quantity;
            this.ResourseType = resourseType;
        }

        public int Quantity { get; }
        public ResourseType ResourseType { get; }
    }
}
