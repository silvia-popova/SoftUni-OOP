using System.Text;

namespace Problem4.WorkForce.IO.Commands
{
    using Problem4.WorkForce.Contracts;

    public class StatusCommand : Command
    {
        public StatusCommand(IData data) : base(data)
        {
        }

        public override string Execute(string[] inputData)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var job in this.Data.Jobs)
            {
                sb.AppendLine(job.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
