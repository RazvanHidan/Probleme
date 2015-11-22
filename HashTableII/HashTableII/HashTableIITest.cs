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

        [TestMethod]
        public void HashContain()
        {
            Hashtable<string, int> phonebook = new Hashtable<string, int>(100);
            phonebook.Add("Razvan Hidan", 0744596712);
            phonebook.Add("Ionut Marin", 076653421);
            phonebook.Add("Bogdan Dragos", 07111111);
            phonebook.Add("Maria Marioara", 0783442);
            phonebook.ContainsKey("Razvan Hidan");
            phonebook.ContainsKey("Bogdan Dragos");
            phonebook.ContainsKey("Razvan").ShouldBeFalse();
        }

        [TestMethod]
        public void DeleteKey()
        {
            Hashtable<string, int> phonebook = new Hashtable<string, int>(100);
            phonebook.Add("Razvan Hidan", 0744596712);
            phonebook.Add("Ionut Marin", 076653421);
            phonebook.Add("Bogdan Dragos", 07111111);
            phonebook.Add("Maria Marioara", 0783442);
            phonebook.Add("Ana Blandiana", 09883773);
            phonebook.Add("Mihai Eminescu", 0038874);
            phonebook.Remove("Razvan Hidan");
            phonebook.ContainsKey("Razvan Hidan").ShouldBeFalse();
            phonebook.Remove("Maria Marioara");
            phonebook.ContainsKey("Maria Marioara").ShouldBeFalse();
        }
    }
}
