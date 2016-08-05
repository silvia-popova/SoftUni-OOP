namespace LambdaCore.Tests
{
    using System;
    using System.Reflection;
    using LambdaCore.Contracts;
    using LambdaCore.Core;
    using LambdaCore.IO.Commands;
    using LambdaCore.Models.Cores;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class AttachFragmentCommandTest
    {
        private ICommand selectCommand;
        private Mock<IPowerPlant> powerPlant;
        private ICore core;

        [TestInitialize]
        public void Initialize()
        {
            core = new ParaCore('A', 3);

            powerPlant = new Mock<IPowerPlant>();
            powerPlant.Setup(c => c.CurrentCore)
                .Returns(core);

            selectCommand = new AttachFragmentCommand(powerPlant.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_WithInvalidType_ShoudThrow()
        {
            var inputData = "AttachFragment:@InvalidType@A32@100".Split(':');
            this.selectCommand.Execute(inputData);
        }

        [TestMethod]
        [ExpectedException(typeof(TargetInvocationException))]
        public void Execute_WithNegativePressureAffection_ShoudThrow()
        {
            var inputData = "AttachFragment:@Nuclear@A32@-100".Split(':');
            this.selectCommand.Execute(inputData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_WithoutCurrentCoreSet_ShoudThrow()
        {
            powerPlant.Setup(c => c.IsCurrentCoreSelected)
                .Returns(false);

            var inputData = "AttachFragment:@Nuclear@A32@100".Split(':');
            this.selectCommand.Execute(inputData);
        }

        [TestMethod]
        public void Execute_WithValidData_ShoudAttacOneFragmentToCurrentCore()
        {
            powerPlant.Setup(c => c.IsCurrentCoreSelected)
                .Returns(true);

            var inputData = "AttachFragment:@Nuclear@A32@100".Split(':');
            this.selectCommand.Execute(inputData);

            Assert.AreEqual(1, this.powerPlant.Object.CurrentCore.CountOfFragments);
        }

        [TestMethod]
        public void Execute_WithValidData_ShoudReturnSuccessMessage()
        {
            powerPlant.Setup(c => c.IsCurrentCoreSelected)
                .Returns(true);

            var inputData = "AttachFragment:@Nuclear@A32@100".Split(':');

            var actualmessage = this.selectCommand.Execute(inputData);
            var expectedMessage = "Successfully attached Fragment A32 to Core A!";

            Assert.AreEqual(expectedMessage, actualmessage);
        }

        [TestMethod]
        public void Execute_WithInValidData_ShoudReturnFailureMessage()
        {
            powerPlant.Setup(c => c.IsCurrentCoreSelected)
                .Returns(true);

            var expectedMessage = "Failed to attach Fragment A32!";

            try
            {
                var inputData = "AttachFragment:@Nuclear@A32@100".Split(':');
                this.selectCommand.Execute(inputData);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}
