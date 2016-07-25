using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IBuilding
    {
        bool CanProduceUnit { get; }

        bool CanProduceResourse { get; }

        void Update();
    }
}
