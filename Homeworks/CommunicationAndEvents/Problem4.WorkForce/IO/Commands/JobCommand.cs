namespace Problem4.WorkForce.IO.Commands
{
    using System.Linq;
    using Problem4.WorkForce.Contracts;
    using Problem4.WorkForce.Models;

    public class JobCommand : Command
    {
        public JobCommand(IData data) 
            : base(data)
        {
        }

        public override string Execute(string[] inputData)
        {
            var employee = this.Data.Employees.FirstOrDefault(e => e.Name == inputData[3]);
            var job = new Job(inputData[1], int.Parse(inputData[2]), employee);

            this.Data.AddJob(job);

            return null;
        }
    }
}
