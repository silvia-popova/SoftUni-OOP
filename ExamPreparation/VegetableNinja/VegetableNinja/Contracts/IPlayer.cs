using VegetableNinja.Models;

namespace VegetableNinja.Contracts
{
    public interface IPlayer : IGameObject
    {
        ICollisionHandler CollisionHandler { get; }

        int Power { get; set; }

        int Stamina { get; set; }

        
    }
}
