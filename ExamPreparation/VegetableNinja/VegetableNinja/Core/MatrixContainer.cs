using VegetableNinja.Contracts;
using VegetableNinja.Core.Exceptions;

namespace VegetableNinja.Core
{
    public class MatrixContainer : IUnitContainer
    {
        private readonly IGameObject[,] unitMatrix;

        public MatrixContainer(int rows, int cols)
        {
            this.unitMatrix = new IGameObject[rows, cols];
        }

        public void Add(IGameObject unit)
        {

            //if (this.unitMatrix[unit.X, unit.Y] != null)
            //{
            //    throw new GameException(string.Format(
            //        "There is already a unit on position [{0},{1}]",
            //        unit.X, unit.Y));
            //}

            this.unitMatrix[unit.X, unit.Y] = unit;
        }

        public void Remove(IGameObject unit)
        {
            if (this.unitMatrix[unit.Y, unit.X] == null)
            {
                throw new GameException("Unit is not present in container");
            }

            this.unitMatrix[unit.Y, unit.X] = null;
        }

        public IGameObject CheckForOtherGameObject(int newX, int newY)
        {
            if (this.IsOutsideTheMatrix(newX, newY))
            {
                return null;
            }

            return this.unitMatrix[newX, newY];
        }

        public void Move(IGameObject unit, int newX, int newY)
        {
            this.unitMatrix[unit.X, unit.Y] = null;

            unit.X = newX;
            unit.Y = newY;
            this.unitMatrix[unit.X, unit.Y] = unit;
        }

        public bool IsOutsideTheMatrix(int x, int y)
        {
            if (!(x >= 0 && x < this.unitMatrix.GetLength(0)) ||
                !(y >= 0 && y < this.unitMatrix.GetLength(1)))
            {
                return true;
            }

            return false;
        }
    }
}

