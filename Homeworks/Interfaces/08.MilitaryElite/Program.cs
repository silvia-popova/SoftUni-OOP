using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.MilitaryElite
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }

    public interface IMission
    {
        string CodeName { get; }

        string State { get; }
    }

    public interface ISoldier
    {
        string FirstName { get; }

        string LastName { get; }

        string Id { get; }
    }

    public interface IPrivate : ISoldier
    {
        double Salary { get; }
    }

    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }

    public interface ILeutenantGeneral : IPrivate
    {
        IEnumerable<IPrivate> Privates { get; }

        void AddPrivate(IPrivate privat);
    }

    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }

    public interface ICommando : ISpecialisedSoldier
    {
        IEnumerable<IMission> Missions { get; }

        void AddMission(IMission mission);
    }

    public interface IEngineer : ISpecialisedSoldier
    {
        IEnumerable<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }

    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"  Part Name: {PartName} Hours Worked: {HoursWorked}");

            return result.ToString();
        }
    }

    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }

        public string State
        {
            get
            {
                return this.state;
            }

            set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    this.state = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("mission state", "Mission state is not valid");
                }
            }
        }
        
        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"  Code Name: {CodeName} State: {state}");

            return result.ToString();
        }
    }

    public class Soldier : ISoldier
    {
        public Soldier(string firstName, string id, string lastName)
        {
            this.FirstName = firstName;
            this.Id = id;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Id { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"Name: {this.FirstName} {LastName} Id: {Id}");

            return result.ToString();
        }
    }

    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string id, string lastName, double salary)
            : base(firstName, id, lastName)
        {
            this.Salary = salary;
        }

        public double Salary { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.Append($" Salary: {Salary:F2}");

            return result.ToString();
        }
    }

    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string id, string lastName, int codeNumber)
            : base(firstName, id, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.Append($"Code Number: {CodeNumber}");

            return result.ToString();
        }
    }

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private List<IPrivate> privates;

        public LeutenantGeneral(string firstName, string id, string lastName, double salary)
             : base(firstName, id, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IEnumerable<IPrivate> Privates => this.privates;

        public void AddPrivate(IPrivate privat)
        {
            if (privat == null)
            {
                throw new ArgumentNullException("privat", "private cannot be null");
            }

            this.privates.Add(privat);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Privates:");

            foreach (var priv in Privates)
            {
                result.AppendLine(priv.ToString());
            }

            return result.ToString().Trim();
        }
    }

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(string firstName, string id, string lastName, double salary, string corps)
            : base(firstName, id, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IEnumerable<IMission> Missions => this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Missions:");

            foreach (var priv in Missions)
            {
                result.AppendLine(priv.ToString());
            }

            return result.ToString().Trim();
        }
    }

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string firstName, string id, string lastName, double salary, string corps)
            : base(firstName, id, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }

            set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("corps", "Corps is not valid");
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.Append($"Corps: {Corps}");

            return result.ToString();
        }
    }

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;

        public Engineer(string firstName, string id, string lastName, double salary, string corps)
            : base(firstName, id, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IEnumerable<IRepair> Repairs => this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Repairs:");

            foreach (var priv in Repairs)
            {
                result.AppendLine(priv.ToString());
            }

            return result.ToString().Trim();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = new StringBuilder();

            string line = Console.ReadLine();

            List<Private> privates = new List<Private>();

            while (line != "End")
            {
                string[] inputArgs = line.Split();

                string soldierType = inputArgs[0];

                switch (soldierType)
                {
                    case "Private":
                        Private privat = new Private(inputArgs[2], inputArgs[1], inputArgs[3], double.Parse(inputArgs[4]));
                        privates.Add(privat);
                        result.AppendLine(privat.ToString());
                        break;
                    case "LeutenantGeneral":
                        LeutenantGeneral leutenant = new LeutenantGeneral(inputArgs[2], inputArgs[1], inputArgs[3], double.Parse(inputArgs[4]));

                        for (int i = 5; i < inputArgs.Length; i++)
                        {
                            string privateId = inputArgs[i];

                            Private privSoldier = privates.FirstOrDefault(p => p.Id == privateId);

                            if (privSoldier != null)
                            {
                                leutenant.AddPrivate(privSoldier);
                            }
                        }

                        result.AppendLine(leutenant.ToString());
                        break;
                    case "Engineer":
                        try
                        {
                            Engineer engineer = new Engineer(inputArgs[2], inputArgs[1], inputArgs[3], double.Parse(inputArgs[4]), inputArgs[5]);

                            for (int i = 6; i < inputArgs.Length - 1; i += 2)
                            {
                                string repairPart = inputArgs[i];
                                int repairHours = int.Parse(inputArgs[i + 1]);

                                var repair = new Repair(repairPart, repairHours);

                                engineer.AddRepair(repair);
                            }

                            result.AppendLine(engineer.ToString());
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                        }
                        break;
                    case "Commando":
                        try
                        {
                            Commando comando = new Commando(inputArgs[2], inputArgs[1], inputArgs[3], double.Parse(inputArgs[4]), inputArgs[5]);

                            for (int i = 6; i < inputArgs.Length - 1; i += 2)
                            {
                                string repairPart = inputArgs[i];
                                string repairHours = inputArgs[i + 1];

                                try
                                {
                                    var mission = new Mission(repairPart, repairHours);
                                    comando.AddMission(mission);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }

                            result.AppendLine(comando.ToString());
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                        }
                        break;
                    case "Spy":
                        Spy spy = new Spy(inputArgs[2], inputArgs[1], inputArgs[3], int.Parse(inputArgs[4]));
                        result.AppendLine(spy.ToString());
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}
