using System.Collections.Generic;
using VegetableNinja.Models;

namespace VegetableNinja.Contracts
{
    public interface ICollisionHandler
    {
        IPlayer Player { get; set; }

        IVegetable SteppedVegetable { get; set; }

        IVegetable PreviouslySteppedVegetable { get; set; }

        IList<IVegetable> CollectedVegetables { get; }

        void AddToCollectedVegetables(IVegetable vegetable);

        IPlayer Fight(IPlayer otherPlayer);

        void CollectFromVegetables();

        void StepOnVegetable(IVegetable steppedVegetable);

        void FreeVegetable();

        event OnMelolemonmelonEatenEventHandler OnMelolemonmelonEaten;
    }
}
