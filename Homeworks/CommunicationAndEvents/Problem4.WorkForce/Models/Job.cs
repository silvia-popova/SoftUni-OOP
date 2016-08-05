using System;

namespace Problem4.WorkForce.Models
{
    using Problem4.WorkForce.Contracts;

    public delegate void OnJobDoneEventHandler(IJob sender, EventArgs eventArgs);

    public class Job : IJob
    {
        public event OnJobDoneEventHandler OnJobDone;

        private string name;
        private int workHoursRequired;
        private IEmploee employee;

        public Job(string name, int workHoursRequired, IEmploee employee)
        {
            this.name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.employee = employee;
        }

        protected int WorkHoursRequired
        {
            get
            {
                return this.workHoursRequired;
            }

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine($"Job {this.name} done!");
                    this.OnJobDone?.Invoke(this, EventArgs.Empty);
                }

                this.workHoursRequired = value;
            }
        }

        public void Update()
        {
            this.WorkHoursRequired -= this.employee.WorkHours;
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.WorkHoursRequired}";
        }
    }
}
