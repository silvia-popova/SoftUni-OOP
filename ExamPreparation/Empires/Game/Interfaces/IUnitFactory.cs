﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IUnitFactory
    {
        IUnit ProduceUnit(string name);
    }
}
