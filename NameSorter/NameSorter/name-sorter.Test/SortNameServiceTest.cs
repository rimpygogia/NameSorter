using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter.Logic.Infrastructure;
using name_sorter.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter.Test
{
    [TestClass]
    public class SortNameServiceTest
    {
        private ISortNamesService _sortNamesService;

        [TestInitialize]
        public void TestInitialize()
        {
            var container = DependencyRegister.Register();
            using (var scope = container.BeginLifetimeScope())
            {
                _sortNamesService = scope.Resolve<ISortNamesService>();
            }
        }

        [TestMethod]
        public void TestSortSingleName()
        {
            List<string> names = new List<string> { "Rimpy" };
            Assert.AreEqual("Rimpy", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 1);
        }

        [TestMethod]
        public void TestSortSimpleNames()
        {
            List<string> names = new List<string> { "Rimpy", "Balbir" };
            Assert.AreEqual("Balbir Rimpy", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        //Sort order by last name. 
        public void TestSortNames_WithFirstAndLastName()
        {
            List<string> names = new List<string> { "Rimpy Ahuja", "Balbir Gogia" };
            Assert.AreEqual("Rimpy Ahuja Balbir Gogia", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        public void TestSortNames_WithFirstAndLastNameAgainInReverseOrder()
        {
            List<string> names = new List<string> { "Balbir Gogia", "Rimpy Ahuja" };
            Assert.AreEqual("Rimpy Ahuja Balbir Gogia", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        public void TestSortNames_WithFirstMiddleLastName()
        {
            List<string> names = new List<string> { "Anhad Manit Lipika", "Prince Kanika Dolly"};
            Assert.AreEqual("Prince Kanika Dolly Anhad Manit Lipika", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        public void TestSortNames_WithLongName()
        {
            List<string> names = new List<string> { "Lucky Malka", "Bittu Narinder Pal Guru", "Prince Kanika Dolly" };
            Assert.AreEqual("Prince Kanika Dolly Lucky Malka Bittu Narinder Pal Guru", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 3);
        }

    }
}
