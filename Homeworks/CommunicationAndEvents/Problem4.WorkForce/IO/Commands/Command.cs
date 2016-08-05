namespace Problem4.WorkForce.IO.Commands
{
    using Problem4.WorkForce.Contracts;

    public abstract class Command : ICommand
    {
        protected Command(IData data)
        {
            this.Data = data;
        }

        protected IData Data { get; }

        public abstract string Execute(string[] inputData);
    }
}
