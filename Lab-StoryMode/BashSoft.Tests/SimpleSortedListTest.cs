namespace BashSoft.Tests
{
    using System;
    using System.Collections.Generic;
    using Executor.Contracts;
    using Executor.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SimpleSortedListTest
    {
        private ISimpleOrderedBag<string> names;

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names =new SimpleSortedList<string>();

            Assert.AreEqual(16, this.names.Capasity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);

            Assert.AreEqual(20, this.names.Capasity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase ,30);

            Assert.AreEqual(30, this.names.Capasity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(16, this.names.Capasity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");

            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrows()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosa");
            this.names.Add("Gosho");
            this.names.Add("Ben");

            var actualList = new List<string>();
            foreach (var name in this.names)
            {
                actualList.Add(name);
            }

            var expectedList = new List<string>() {"Ben", "Gosho", "Rosa"};

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void TestAddUnsortedDataWithCustomComparatorIsHeldSorted()
        {
            this.names = new SimpleSortedList<string>(StringComparer.InvariantCulture);
            this.names.Add("Adi");
            this.names.Add("adi");
            this.names.Add("pesho");
            this.names.Add("#pesho");

            var expectedList = new List<string> { "Adi", "adi", "pesho" , "#pesho" };
            expectedList.Sort(StringComparer.InvariantCulture);

            var actualList = new List<string>();
            foreach (var name in this.names)
            {
                actualList.Add(name);
            }

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("pesho");
            }

            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capasity);
        }

        [TestMethod]
        public void TestAddAllFromCollectionIncreasesSize()
        {
            var collection = new List<string>{ "Ben", "Gosho"};

            this.names.AddAll(collection);

            Assert.AreEqual(2, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddAllFromNullThrows()
        {
            this.names.AddAll(null);
        }

        [TestMethod]
        public void TestAddAllMoreThanInitialCapacity()
        {
            var collection = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                collection.Add("pesho");
            }

            this.names.AddAll(collection);

            Assert.AreEqual(32, this.names.Capasity);
        }

        [TestMethod]
        public void TestAddAllUnsortedCollectionIsHeldSorted()
        {
            var collection = new List<string>{ "Stive", "Lee", "Young" };

            this.names.AddAll(collection);
            
            var actualList = new List<string>();
            foreach (var name in this.names)
            {
                actualList.Add(name);
            }

            collection.Sort();

            CollectionAssert.AreEqual(collection, actualList);
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Adi");
            this.names.Remove("Adi");

            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Adi");
            this.names.Add("Nase");
            this.names.Remove("Nase");

            foreach (var name in this.names)
            {
                Assert.AreNotEqual("Nase", name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveNullShouldThrow()
        {
            this.names.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNullShouldThrow()
        {
            this.names.Add("Adi");
            this.names.Add("Nase");
            this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWithWorksFine()
        {
            this.names.Add("Adi");
            this.names.Add("Nase");
            string result = this.names.JoinWith(", ");

            Assert.AreEqual("Adi, Nase", result);
        }
    }
}
