namespace Problem4.WorkForce.IO.Commands
{
    using Problem4.WorkForce.Contracts;
    using Problem4.WorkForce.Models;

    public class StandartEmployeeCommand : Command
    {
        public StandartEmployeeCommand(IData data) 
            : base(data)
        {
        }

        public override string Execute(string[] inputData)
        {
            var employee = new StandartEmployee(inputData[1]);

            this.Data.Employees.Add(employee);

            return null;
        }
    }
}

