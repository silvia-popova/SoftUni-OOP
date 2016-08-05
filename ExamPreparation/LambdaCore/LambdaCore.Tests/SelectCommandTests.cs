namespace LambdaCore.Tests
{
    using System;
    using LambdaCore.Contracts;
    using LambdaCore.Core;
    using LambdaCore.IO.Commands;
    using LambdaCore.Models.Cores;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SelectCommandTests
    {
        private ICommand selectCommand;
        private IPowerPlant powerPlant;

        [TestInitialize]
        public void Initialize()
        {
            powerPlant = new PowerPlant();
            selectCommand = new SelectCoreCommand(powerPlant);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExecuteWithInvalidInputShouldThrow()
        {
            var inputData = "SelectCore:@A@Cooling@A64".Split(':');
            this.selectCommand.Execute(inputData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExecuteWithUnexistingCoreShouldThrow()
        {
            var inputData = "SelectCore:@A".Split(':');
            this.selectCommand.Execute(inputData);
        }

        [TestMethod]
        public void TestExecuteWithUnexistingCoreShouldReturnCorrectMessage()
        {
            try
            {
                var inputData = "SelectCore:@A".Split(':');
                this.selectCommand.Execute(inputData);
            }
            catch (Exception ex)
            {
                
                Assert.AreEqual("Failed to select Core A!", ex.Message);
            }
        }

        [TestMethod]
        public void TestExecuteWithExistingCoreShouldReturnCorrectMessage()
        {
            this.powerPlant.AddCore(new ParaCore('A', 2));

            var inputData = "SelectCore:@A".Split(':');
            var actualMessage = this.selectCommand.Execute(inputData);
            var expectedMessage = "Currently selected Core A!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void TestExecuteWithExistingCoreShouldSetCurrentCore()
        {
            var core = new ParaCore('A', 2);
            this.powerPlant.AddCore(core);

            var inputData = "SelectCore:@A".Split(':');
            this.selectCommand.Execute(inputData);

            Assert.AreEqual(core, this.powerPlant.CurrentCore);
        }
    }
}
