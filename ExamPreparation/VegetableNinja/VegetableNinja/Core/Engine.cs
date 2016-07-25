using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VegetableNinja.Contracts;
using VegetableNinja.Models;

namespace VegetableNinja.Core
{
    public sealed class Engine : IEngine
    {
        private bool isStarted;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly IUnitContainer unitContainer;
        private readonly IPlayer[] players;
        private readonly IList<IVegetable> vegetables;

        public Engine(IUnitContainer unitContainer,
            IInputReader reader,
            IOutputWriter writer,
            IPlayer[] players,
            IList<IVegetable> vegetables)
        {
            this.players = players;
            this.vegetables = vegetables;
            this.unitContainer = unitContainer;
            this.writer = writer;
            this.reader = reader;
        }

        public IUnitContainer UnitContainer
        {
            get { return this.unitContainer; }
        }

        public IOutputWriter OutputWriter
        {
            get { return this.writer; }
        }

        public void Start()
        {
            this.isStarted = true;
            
            int playerIndex = 0;

            foreach (var player in players)
            {
                player.CollisionHandler.OnMelolemonmelonEaten += EatMushrooms;
            }

            while (this.isStarted)
            {
                string commands = this.reader.ReadNextLine();

                foreach (var s in commands)
                {
                    IPlayer currentPlayer = players[playerIndex % 2];

                    int newX = currentPlayer.X;
                    int newY = currentPlayer.Y;

                    if (s == 'R')
                    {
                        newY ++;
                    }
                    else if (s == 'L')
                    {
                        newY--;
                    }
                    else if (s == 'D')
                    {
                        newX++;
                    }
                    else if (s == 'U')
                    {
                        newX--;
                    }

                    currentPlayer.Stamina--;

                    

                    IGameObject newObject = this.unitContainer.CheckForOtherGameObject(newX, newY);
                    
                    if (!this.unitContainer.IsOutsideTheMatrix(newX, newY))
                    {
                        HandleCollision(currentPlayer, newObject);

                        this.unitContainer.Move(currentPlayer, newX, newY);

                        if (currentPlayer.CollisionHandler.PreviouslySteppedVegetable != null)
                        {
                            currentPlayer.CollisionHandler.FreeVegetable();
                            this.unitContainer.Add(currentPlayer.CollisionHandler.PreviouslySteppedVegetable);
                            currentPlayer.CollisionHandler.PreviouslySteppedVegetable = null;
                        }
                    }

                    if (currentPlayer.Stamina == 0)
                    {
                        playerIndex++;
                        currentPlayer.CollisionHandler.CollectFromVegetables();
                    }

                    GrowVegetables();
                }
            }
        }

        private void GrowVegetables()
        {
            foreach (var vegetable in vegetables)
            {
                vegetable.Grow();
            }
        }

        private void HandleCollision(IPlayer currentPlayer, IGameObject newObject)
        {
            if (newObject is IPlayer)
            {
                IPlayer winner = currentPlayer.CollisionHandler.Fight(newObject as IPlayer);
                HandeWinner(winner);
            }
            else if (newObject is IVegetable)
            {
                IVegetable vegetable = newObject as IVegetable;
                currentPlayer.CollisionHandler.PreviouslySteppedVegetable = currentPlayer.CollisionHandler.SteppedVegetable;
                currentPlayer.CollisionHandler.SteppedVegetable = vegetable;
                currentPlayer.CollisionHandler.AddToCollectedVegetables(vegetable);
                currentPlayer.CollisionHandler.StepOnVegetable(vegetable);
            }
            else
            {
                currentPlayer.CollisionHandler.PreviouslySteppedVegetable = currentPlayer.CollisionHandler.SteppedVegetable;
                currentPlayer.CollisionHandler.SteppedVegetable = null;
            }
        }

        private void HandeWinner(IPlayer winner)
        {
            var output= new StringBuilder();

            output.AppendLine($"Winner: {winner.Name}");
            output.AppendLine($"Power: {winner.Power}");
            output.AppendLine($"Stamina: {winner.Stamina}");

            this.OutputWriter.Write(output.ToString());

            Environment.Exit(0);
        }

        public void Stop()
        {
            this.isStarted = false;
        }

        private void EatMushrooms(ICollisionHandler sender, EventArgs eventargs)
        {
            var player = players.FirstOrDefault(p => p.CollisionHandler != sender);
            var mushroom= new Mushroom(0,0);

            for (int i = 0; i < 5; i++)
            {
                player.Stamina += mushroom.StaminaPoints;
                player.Power += mushroom.PowerPoints;
            }
        }
    }
}
