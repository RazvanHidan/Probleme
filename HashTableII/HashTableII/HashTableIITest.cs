using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace HashTableII
{
    [TestClass]
    public class HashTableIITest
    {
        [TestMethod]
        public void HashtableIsEmty()
        {
            Hashtable<string, int> phonebook = new Hashtable<string, int>();
            phonebook.Count.ShouldEqual(0);
        }

        [TestMethod]
        public void Size_Initialization_Hashtable()
        {
            Hashtable<string, int> phonebook = new Hashtable<string, int>(10);
            phonebook.Count.ShouldEqual(0);
        }

        [TestMethod]
        public void AddToHashtable()
        {
            Hashtable<string, int> phonebook = new Hashtable<string, int>(100);
            phonebook.Add("Razvan Hidan", 0744596712);
            phonebook.Count.ShouldEqual(1);
            phonebook.Add("Ionut Marin", 076653421);
            phonebook.Count.ShouldEqual(2);
        }
    }
}
