namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data
        {
            get
            {
                return this.data;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("data", "Data cannot be null");
                }

                this.data = value;
            }
        }

        protected IRepository Repository
        {
            get
            {
                return this.repository;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("repository", "Repository cannot be null");
                }

                this.repository = value;
            }
        }

        protected IUnitFactory UnitFactory
        {
            get
            {
                return this.unitFactory;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("unitFactory", "UnitFactory cannot be null");
                }

                this.unitFactory = value;
            }
        }

        public abstract void Execute();
    }
}
