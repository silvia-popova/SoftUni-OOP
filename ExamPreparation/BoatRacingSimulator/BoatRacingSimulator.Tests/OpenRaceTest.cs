namespace BoatRacingSimulator.Tests
{
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OpenRaceTest
    {
        private IBoatSimulatorController controller;

        [TestInitialize]
        public void SetUp()
        {
            this.controller = new BoatSimulatorController();
        }

        [TestMethod]
        public void TestOpenRaceWithNoCurrentRaceShouldReturnSuccessMessage()
        {
            var actualResult = this.controller.OpenRace(2, 3, 4, true);
            var expectedResult = "A new race with distance 2 meters, wind speed 3 m/s and ocean current speed 4 m/s has been set.";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOpenRaceWithNoCurrentRaceShouldSetTheRace()
        {
            this.controller.OpenRace(2, 3, 4, true);

            Assert.IsNotNull(this.controller.CurrentRace);
        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException))]
        public void TestOpenRaceWithCurrentRaceAlreadySetShouldThrow()
        {
            this.controller.OpenRace(2, 3, 4, true);
            this.controller.OpenRace(5, 7, 4, false);
        }
    }
}
