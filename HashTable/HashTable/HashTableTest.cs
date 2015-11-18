using System;
using Should;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void LibraryIsEmty()
        {
            var diverta = new Library();
            diverta.keys.ShouldBeNull();
        }

        [TestMethod]
        public void LibraryUniqueAdd()
        {
            var diverta = new Library();
            diverta.Add("Ion ");
            diverta.Add("Ion Praslea");
            diverta.Add("Mara");
            diverta.keys.ShouldContain("Ion ");
            diverta.keys.ShouldContain("Ion Praslea");
            diverta.keys.ShouldContain("Mara");
        }
        [TestMethod]
        public void LibraryAdd()
        {
            var diverta = new Library();
            diverta.Add("Ion");
            diverta.Add("Ion Praslea");
            diverta.Add("Mara");
            diverta.keys.ShouldContain("Ion");
            diverta.keys.ShouldContain("Ion Praslea");
            diverta.keys.ShouldContain("Mara");
        }

        [TestMethod]
        public void ElementExistInLibrary()
        {
            var diverta = new Library();
            diverta.Add("Ion");
            diverta.Add("Ion Praslea");
            diverta.Add("Mara");
            diverta.Find("Ion");
            diverta.Find("Ion Praslea");
            diverta.Find("Mara");
        }

        [TestMethod]
        public void ElementNOTExistInLibrary()
        {
            var diverta = new Library();
            diverta.Add("1234");
            diverta.Add("2341");
            diverta.Find("1234").ShouldBeTrue();
            diverta.Find("2341").ShouldBeTrue();
            diverta.Find("1324").ShouldBeFalse();
        }
    }
}
