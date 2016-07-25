using System;
using System.Collections.Generic;
using VegetableNinja.Contracts;

namespace VegetableNinja.Models
{
    public class CollisionHandler : ICollisionHandler
    {
        private IList<IVegetable> collectedVegetables;

        public CollisionHandler(IPlayer player)
        {
            this.Player = player;
            this.collectedVegetables = new List<IVegetable>();
        }

        public IPlayer Player { get; set; }

        public IVegetable SteppedVegetable { get; set; }

        public IVegetable PreviouslySteppedVegetable { get; set; }

        public IList<IVegetable> CollectedVegetables => this.collectedVegetables;

        public void AddToCollectedVegetables(IVegetable vegetable)
        {
            this.collectedVegetables.Add(vegetable);
        }

        public IPlayer Fight(IPlayer otherPlayer)
        {
            if (this.Player.Power >= otherPlayer.Power)
            {
                return this.Player;
            }

            return otherPlayer;
        }

        public void CollectFromVegetables()
        {
            if (this.collectedVegetables != null)
            {
                foreach (var vegetable in this.collectedVegetables)
                {
                    if (vegetable is Melolemonmelon)
                    {
                        this.OnMelolemonmelonEaten?.Invoke(this, EventArgs.Empty);
                    }

                    //this.Player.Stamina += vegetable.StaminaPoints;
                    //this.Player.Power += vegetable.PowerPoints;

                    if (!vegetable.IsGrowing)
                    {
                        this.Player.Stamina += vegetable.StaminaPoints;
                        this.Player.Power += vegetable.PowerPoints;
                    }

                    vegetable.IsGrowing = true;
                }

                this.collectedVegetables.Clear();
            }
        }

        public void StepOnVegetable(IVegetable steppedVegetable)
        {
            this.SteppedVegetable.IsSteppedOn = true;
        }

        public void FreeVegetable()
        {
            this.PreviouslySteppedVegetable.IsSteppedOn = false;
            //this.PreviouslySteppedVegetable.IsGrowing = true;
        }

        public void DecreaseStamina()
        {
            this.Player.Stamina --;
        }

        public event OnMelolemonmelonEatenEventHandler OnMelolemonmelonEaten;
    }
}
