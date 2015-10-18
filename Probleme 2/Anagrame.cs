using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrame
{
    [TestClass]
    public class Anagrame
    {
        [TestMethod]
        public void TestAnagrame()
        {
            Assert.AreEqual(CalculateAnagram("Math"),24);
        }
        long Permutation(int number)
        {
            long n = 1;
            for (int i = 1; i <= number; i++)
                n *= i;
            return n;
        }
        long CalculateAnagram(string word)
        {
            return Permutation(word.Length);
        }
    }
}
