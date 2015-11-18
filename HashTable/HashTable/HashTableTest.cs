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
    }
}
