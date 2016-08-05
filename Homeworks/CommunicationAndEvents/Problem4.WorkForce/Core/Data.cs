namespace Problem4.WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using Problem4.WorkForce.Contracts;

    public class Data : IData
    {
        private List<IEmploee> employees;
        private List<IJob> jobs;

        public Data()
        {
            this.jobs=new List<IJob>();
            this.employees=new List<IEmploee>();
        }

        public List<IEmploee> Employees => this.employees;

        public List<IJob> Jobs => this.jobs;

        public void AddJob(IJob job)
        {
            job.OnJobDone += this.RemoveJob;
            this.jobs.Add(job);
        }

        private void RemoveJob(IJob sender, EventArgs eventargs)
        {
            sender.OnJobDone -= this.RemoveJob;
            this.jobs.Remove(sender);
        }
    }
}
