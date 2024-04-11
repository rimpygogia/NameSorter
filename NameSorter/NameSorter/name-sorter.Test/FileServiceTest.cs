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
    public class FileServiceTest
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
        public void Test_ReadInputFile()
        {
            var names = _sortNamesService.GetUnsortedNames("../../TestFiles/TestInputFile.txt");
            Assert.AreEqual("Bawa Ekta Thiya Aery", String.Join(" ", names));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        public void Test_WriteNamesToOutputFile()
        {
            List<string> output = new List<string>
            {
               "Manmohan Akshay", "Diksha Shiv"
            };
            _sortNamesService.WriteSortedNames("../../TestFiles/TestOutputFile.txt", output);
            Assert.AreEqual("Manmohan Akshay Diksha Shiv", String.Join(" ", output));
        }

        [TestMethod]
        public void Test_ValidateInputArgument_ValidArgument()
        {
            string[] input = { "../../TestFiles/TestInputFile.txt" };
            var valid = _sortNamesService.ValidateFile(input);
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void Test_ValidateInputArgument_InValidFilename()
        {
            string[] input = { "../../TestFiles/TestInvalid.txt" };
            var valid = _sortNamesService.ValidateFile(input);
            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void Test_ValidateInputArgument_InValidArgument()
        {
            string[] input = { "XYZ019" };
            var valid = _sortNamesService.ValidateFile(input);
            Assert.AreEqual(false, valid);
        }
    }
}
