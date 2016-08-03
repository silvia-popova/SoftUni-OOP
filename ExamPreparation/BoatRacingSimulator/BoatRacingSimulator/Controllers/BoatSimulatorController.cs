namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Enumerations;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;
    using BoatRacingSimulator.Models.BoteEngines;
    using BoatRacingSimulator.Models.Botes;
    using BoatRacingSimulator.Utility;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(IBoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController() : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public IBoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IBoatEngine engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.BoteEngines.Add(engine);
            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
                model,
                horsepower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);

            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);
            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            IBoatEngine firstEngine = this.Database.BoteEngines.GetItem(firstEngineModel);
            IBoatEngine secondEngine = this.Database.BoteEngines.GetItem(secondEngineModel);
            IBoat boat = new PowerBoat(model, weight, firstEngine, secondEngine);
            this.Database.Boats.Add(boat);

            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            IBoatEngine engine = this.Database.BoteEngines.GetItem(engineModel);
            IBoat boat = new Yacht(model, weight, engine, cargoWeight);
            this.Database.Boats.Add(boat);
            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);

            if (race == null)
            {
                throw new ArgumentNullException();
            }

            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;

            return string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance, 
                    windSpeed, 
                    oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            IBoat boat = this.Database.Boats.GetItem(model);

            this.ValidateRaceIsSet();

            if (!this.CurrentRace.AllowsMotorboats && (boat is Yacht || boat is PowerBoat))
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);

            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();

            var participants = this.CurrentRace.GetParticipants();

            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var positiveTimeParticipants = participants.Where(x => x.CalculateRaceTime(this.CurrentRace) > 0).OrderBy(x => x.CalculateRaceTime(this.CurrentRace)).ToList();
            var notFinished = participants.Where(x => x.CalculateRaceTime(this.CurrentRace) <= 0).ToList();
            positiveTimeParticipants.AddRange(notFinished);

            var first = positiveTimeParticipants[0];
            var firstTime = first.CalculateRaceTime(this.CurrentRace);
            var second = positiveTimeParticipants[1];
            var secondTime = second.CalculateRaceTime(this.CurrentRace);
            var third = positiveTimeParticipants[2];
            var thirdTime = third.CalculateRaceTime(this.CurrentRace);

            var result = new StringBuilder();
            result.AppendLine(string.Format(
                "First place: {0} Model: {1} Time: {2}",
                first.GetType().Name,
                first.Model,
                firstTime <= 0 ? "Did not finish!" : firstTime.ToString("0.00") + " sec"));
            result.AppendLine(string.Format(
                "Second place: {0} Model: {1} Time: {2}",
                second.GetType().Name,
                second.Model,
                secondTime <= 0 ? "Did not finish!" : secondTime.ToString("0.00") + " sec"));
            result.Append(string.Format(
                "Third place: {0} Model: {1} Time: {2}",
                third.GetType().Name,
                third.Model,
                thirdTime <= 0 ? "Did not finish!" : thirdTime.ToString("0.00") + " sec"));

            this.CurrentRace = null;

            return result.ToString();
        }

        public string GetStatistic()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();



            StringBuilder output = new StringBuilder();


            return output.ToString();
        }

        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
        {
            double bestTime = double.MaxValue; 
            IBoat winner = null;

            foreach (var participant in participants)
            {
                var time = participant.CalculateRaceTime(this.CurrentRace);
                if (time < bestTime && time > 0)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            if (winner == null)
            {
                winner = participants.First(b => b.CalculateRaceTime(this.CurrentRace) <= 0);
                bestTime = winner.CalculateRaceTime(this.CurrentRace);
            }

            return new KeyValuePair<double, IBoat>(bestTime, winner);
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}
