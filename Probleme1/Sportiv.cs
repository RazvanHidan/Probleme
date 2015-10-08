using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sportiv
{
    [TestClass]
    public class Sportiv
    {
        [TestMethod]
        public void Repetition()
        {
            Assert.AreEqual(Repetition(3), 9);
            Assert.AreEqual(Repetition(10), 100);
            Assert.AreEqual(Repetition(4), 16);
        }
        int Repetition(int n)
        {
            return n * n;
        }
    }
}