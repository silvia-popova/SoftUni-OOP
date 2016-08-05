namespace LambdaCore.Tests
{
    using System;
    using LambdaCore.Contracts;
    using LambdaCore.Exceptions;
    using LambdaCore.IO.Commands;
    using LambdaCore.Models.Cores;
    using LambdaCore.Models.Fragments;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class DetachFragmentCommandTests
    {
        private ICommand detachCommand;
        private Mock<IPowerPlant> powerPlant;
        private ICore core;

        [TestInitialize]
        public void Initialize()
        {
            core = new ParaCore('A', 3);

            powerPlant = new Mock<IPowerPlant>();
            powerPlant.Setup(c => c.CurrentCore)
                .Returns(core);

            this.detachCommand = new DetachFragmentCommand(powerPlant.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_WithNoFragmentsAttachedToCurrentlySelectedCore_ShouldThrow()
        {
            powerPlant.Setup(c => c.IsCurrentCoreSelected)
                .Returns(true);

            var inputData = "DetachFragment:".Split(':');
            this.detachCommand.Execute(inputData);
        }

        [TestMethod]
        [ExpectedException(typeof(CurrentCoreNotSetException))]
        public void Execute_WithNoCurrentlySelectedCore_ShouldThrow()
        {
            powerPlant.Setup(c => c.IsCurrentCoreSelected)
                .Returns(false);

            var inputData = "DetachFragment:".Split(':');
            this.detachCommand.Execute(inputData);
        }

        [TestMethod]
        public void Execute_WithValidData_ShouldReturnSuccessMessage()
        {
            powerPlant.Setup(c => c.IsCurrentCoreSelected)
                .Returns(true);
            this.powerPlant.Object.CurrentCore.AddFragment(new NuclearFragment("fr", 2));

            var inputData = "DetachFragment:".Split(':');

            var actualMessage = this.detachCommand.Execute(inputData);
            var expectedMessage = "Successfully detached Fragment fr from Core A!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
