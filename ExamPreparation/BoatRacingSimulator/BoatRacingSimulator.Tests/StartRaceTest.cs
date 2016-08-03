namespace BoatRacingSimulator.Tests
{
    using System.Collections.Generic;
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models.BoteEngines;
    using BoatRacingSimulator.Models.Botes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StartRaceTest
    {
        private IBoatSimulatorController controller;
        private List<IBoat> testBoats;
        private List<IBoatEngine> testEngines;

        [TestInitialize]
        public void Initialize()
        {
            var engine1 = new JetEngine("engine1", 10, 100);
            var engine2 = new SterndriveEngine("engine2", 10, 100);

            var boat1 = new RowBoat("Rowboat1", 50, 1);
            var boat2 = new SailBoat("Sailboat1", 100, 1);
            var boat3 = new PowerBoat("Powerboat1", 20, engine1, engine2);
            var boat4 = new Yacht("Yacht1", 10, engine2, 10);
            var boat5 = new PowerBoat("Powerboat2", 20, engine1, engine2);
            var boat6 = new SailBoat("Sailboat2", 100, 1);
            var boat7 = new SailBoat("Sailboat3", 100, 1);

            this.controller = new BoatSimulatorController();
            this.testEngines = new List<IBoatEngine>() { engine1, engine2 };
            this.testBoats = new List<IBoat>() { boat1, boat2, boat3, boat4, boat5, boat6, boat7 };
        }

        [TestMethod]
        [ExpectedException(typeof(NoSetRaceException))]
        public void TestStartRaceWithNoCurrentRaceSetShouldThrow()
        {
            this.controller.StartRace();
            //try
            //{
            //    controller.StartRace();
            //}
            //catch (NoSetRaceException ex)
            //{
            //    Assert.AreEqual("There is currently no race set.", ex.Message);
            //}
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientContestantsException))]
        public void TestStartRaceWithZeroContestantsShouldThrow()
        {
            this.controller.OpenRace(2, 3, 4, true);
            this.controller.StartRace();
        }

        [TestMethod]
        public void TestStartRaceWithBoatThatNeverWillFinishShouldPrintCorrectOutput()
        {
            this.controller.OpenRace(1, 1, 1, true);

            this.controller.CurrentRace.AddParticipant(this.testBoats[1]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[5]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[6]);
            var result = this.controller.StartRace();

            Assert.AreEqual(
                "First place: SailBoat Model: Sailboat1 Time: Did not finish!\r\n" +
                "Second place: SailBoat Model: Sailboat2 Time: Did not finish!\r\n" +
                "Third place: SailBoat Model: Sailboat3 Time: Did not finish!",
                result);
        }

        [TestMethod]
        public void TestStartRaceWithValitInputShouldRemoveCurrentRace()
        {
            this.controller.OpenRace(1, 1, 1, true);

            this.controller.CurrentRace.AddParticipant(this.testBoats[1]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[5]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[6]);
            this.controller.StartRace();

            Assert.IsNull(this.controller.CurrentRace);
        }

        [TestMethod]
        public void StartRace_WithBothFinishedAndUnfinishedBoats_ShouldPrintUnfinishedBehindFinishedBoats()
        {
            this.controller.OpenRace(300, 0, 0, true);
            this.controller.CurrentRace.AddParticipant(this.testBoats[1]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[2]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[3]);
            var result = this.controller.StartRace();

            Assert.AreEqual(
                "First place: PowerBoat Model: Powerboat1 Time: 1.00 sec\r\n" +
                "Second place: Yacht Model: Yacht1 Time: 2.00 sec\r\n" +
                "Third place: SailBoat Model: Sailboat1 Time: Did not finish!",
                result);
        }

        [TestMethod]
        public void StartRace_WithBoatsWithSameTime_ShouldPrintThemInOrderOfAdding()
        {
            this.controller.OpenRace(300, 0, 0, true);
            this.controller.CurrentRace.AddParticipant(this.testBoats[1]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[4]);
            this.controller.CurrentRace.AddParticipant(this.testBoats[2]);
            var result = this.controller.StartRace();

            Assert.AreEqual(
                "First place: PowerBoat Model: Powerboat1 Time: 1.00 sec\r\n" +
                "Second place: Yacht Model: Yacht1 Time: 2.00 sec\r\n" +
                "Third place: SailBoat Model: Sailboat1 Time: Did not finish!",
                result);
        }


    }
}
