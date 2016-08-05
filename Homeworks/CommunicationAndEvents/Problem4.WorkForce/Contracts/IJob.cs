namespace Problem4.WorkForce.Contracts
{
    using Problem4.WorkForce.Models;

    public interface IJob
    {
        event OnJobDoneEventHandler OnJobDone;

        void Update();
    }
}
