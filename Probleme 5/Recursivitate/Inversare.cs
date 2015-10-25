using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recursivitate
{
    [TestClass]
    public class Inversare
    {
        [TestMethod]
        public void Test1Inversion()
        {
            Assert.AreEqual("ytrewq", Inverson("qwerty"));
        }
        [TestMethod]
        public void Test1Replace()
        {
            Assert.AreEqual("qwereplacety", Replace("qwerty", 'r', "replace"));
        }
        string Inverson(string word)
        {
            if (word.Length == 1) return word;
            return word[word.Length - 1] + Inverson(word.Remove(word.Length - 1));
        }
        string Replace(string word, char target, string replace)
        {
            if (word[word.Length - 1] == target)  
                return Replace(word.Remove(word.Length - 1), target, replace) + replace;
            if (word.Length == 1) 
                return word;
            return Replace(word.Remove(word.Length - 1), target, replace) + word[word.Length - 1];
        }
    }
}
