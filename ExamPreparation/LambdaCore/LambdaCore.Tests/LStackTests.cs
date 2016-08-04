namespace LambdaCore.Tests
{
    using System;
    using System.Collections.Generic;
    using LambdaCore.Collection;
    using LambdaCore.Models.Fragments;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LStackTests
    {
        private LStack<IFragment> fragments;

        [TestInitialize]
        public void SetUp()
        {
            this.fragments = new LStack<IFragment>();
        }

        [TestMethod]
        public void TestEmptyStackShoudReturnCountZero()
        {
            Assert.AreEqual(0, this.fragments.Count());
        }

        [TestMethod]
        public void TestPushIncreasesSize()
        {
            this.fragments.Push(new NuclearFragment("Test", 1));

            Assert.AreEqual(1, this.fragments.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPushNullThrows()
        {
            this.fragments.Push(null);
        }

        [TestMethod]
        public void TestPeekShoulReturnLastElement()
        {
            var firstFragment = new NuclearFragment("Test1", 1);
            var secondFragment = new NuclearFragment("Test2", 2);
            this.fragments.Push(firstFragment);
            this.fragments.Push(secondFragment);

            var result = this.fragments.Peek();

            Assert.AreEqual(secondFragment, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPeekFromEmptyStackShouldThrow()
        {
            this.fragments.Peek();
        }

        [TestMethod]
        public void TestPeekShoulReturnLastElementWhithoutDecreasingCount()
        {
            var firstFragment = new NuclearFragment("Test1", 1);
            var secondFragment = new NuclearFragment("Test2", 2);
            this.fragments.Push(firstFragment);
            this.fragments.Push(secondFragment);

            this.fragments.Peek();

            Assert.AreEqual(2, this.fragments.Count());
        }

        [TestMethod]
        public void TestPopShoulReturnLastElement()
        {
            var firstFragment = new NuclearFragment("Test1", 1);
            var secondFragment = new NuclearFragment("Test2", 2);
            this.fragments.Push(firstFragment);
            this.fragments.Push(secondFragment);

            var result = this.fragments.Pop();

            Assert.AreEqual(secondFragment, result);
        }

        [TestMethod]
        public void TestPopShoulRemoveLastElement()
        {
            var firstFragment = new NuclearFragment("Test1", 1);
            var secondFragment = new NuclearFragment("Test2", 2);
            this.fragments.Push(firstFragment);
            this.fragments.Push(secondFragment);

            this.fragments.Pop();

            var actualResult = new List<IFragment>();
            var expectedResult = new List<IFragment> {firstFragment};

            foreach (var fragment in this.fragments)
            {
                actualResult.Add(fragment);
            }

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPopFromEmptyStackShouldThrow()
        {
            this.fragments.Pop();
        }

        [TestMethod]
        public void TestPopShouldDecreasingCount()
        {
            var firstFragment = new NuclearFragment("Test1", 1);
            var secondFragment = new NuclearFragment("Test2", 2);
            this.fragments.Push(firstFragment);
            this.fragments.Push(secondFragment);

            this.fragments.Pop();

            Assert.AreEqual(1, this.fragments.Count());
        }

        [TestMethod]
        public void TestIsEmptyWithEmptyStackShouldReturnTrue()
        {
            Assert.IsTrue(this.fragments.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmptyWithNotEmptyStackShouldReturnFalse()
        {
            this.fragments.Push(new NuclearFragment("Test1", 1));
            Assert.IsFalse(this.fragments.IsEmpty());
        }
    }
}
