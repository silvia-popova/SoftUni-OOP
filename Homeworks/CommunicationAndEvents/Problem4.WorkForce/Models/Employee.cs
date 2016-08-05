namespace Problem4.WorkForce.Models
{
    using Problem4.WorkForce.Contracts;

    public abstract class Employee : IEmploee
    {
        protected Employee(string name, int workHours)
        {
            this.Name = name;
            this.WorkHours = workHours;
        }

        public string Name { get; }

        public int WorkHours { get; }
    }
}
