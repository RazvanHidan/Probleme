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
            diverta.entries[6].value.ShouldContain("Ion");
            diverta.entries[6].value.ShouldContain("Ion Praslea");
        }
    }
}
