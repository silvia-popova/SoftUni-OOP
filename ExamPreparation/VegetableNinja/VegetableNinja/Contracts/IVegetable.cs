namespace VegetableNinja.Contracts
{
    public interface IVegetable : IGameObject 
    {
        int PowerPoints { get; set; }

        int StaminaPoints { get; set; }

        int GrowingTime { get; set; }

        bool IsGrowing { get; set; }

        bool IsSteppedOn { get; set; }

        void Grow();
    }
}
