namespace BoatRacingSimulator.Tests
{
    using System;
    using System.Collections.Generic;
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;
    using BoatRacingSimulator.Models.BoteEngines;
    using BoatRacingSimulator.Models.Botes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class SignUpBoatTest
    {
        private IBoatSimulatorController controller;
        private Mock<IBoatSimulatorDatabase> fakeDb;
        private IRace race;

        [TestInitialize]
        public void Initialize()
        {
            var engine = new SterndriveEngine("engine", 10, 100);
            var boat1 = new RowBoat("Rowboat1", 50, 1);
            var boat2 = new Yacht("Yacht1", 10, engine, 10);

            this.fakeDb = new Mock<IBoatSimulatorDatabase>();
            this.fakeDb.Setup(x => x.Boats.GetItem("noEngine")).Returns(boat1);
            this.fakeDb.Setup(x => x.Boats.GetItem("engine")).Returns(boat2);

            this.race = new Race(1, 1, 1, false);
        }

        [ExpectedException(typeof(NoSetRaceException))]
        [TestMethod]
        public void SignUpBoat_WithNoSetCurrentRace_ShoudThrow()
        {
            this.controller = new BoatSimulatorController(this.fakeDb.Object, null);

            this.controller.SignUpBoat("noEngine");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void SignUpBoat_NotAlloudToEnterRace_ShoudThrow()
        {
            this.controller = new BoatSimulatorController(this.fakeDb.Object, race);

            this.controller.SignUpBoat("engine");
        }

        [TestMethod]
        public void SignUpBoat_WithValidInput_ShoudReturnCorrectmessage()
        {
            this.controller = new BoatSimulatorController(this.fakeDb.Object, race);

            var actualResult = this.controller.SignUpBoat("noEngine");
            var ecpectedResult = "Boat with model noEngine has signed up for the current Race.";

            Assert.AreEqual(ecpectedResult, actualResult);
        }

        [TestMethod]
        public void SignUpBoat_WithValidInput_ShoudAddBoatToCurrentRaceParticipants()
        {
            this.controller = new BoatSimulatorController(this.fakeDb.Object, race);

            this.controller.SignUpBoat("noEngine");

            Assert.AreEqual(1, this.controller.CurrentRace.GetParticipants().Count);
        }
    }
}
