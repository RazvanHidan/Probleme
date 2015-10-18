using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loto
{
    [TestClass]
    public class Lotto
    {
        [TestMethod]
        public void TestLotto()
        {
            Assert.AreEqual(ChancesToWin(4, 49), 211876);
            Assert.AreEqual(ChancesToWin(5, 49), 1906884);
            Assert.AreEqual(ChancesToWin(6, 49), 13983816);
            Assert.AreEqual(ChancesToWin(5, 40), 658008);
        }
        long ChancesToWin( int luckyNumbers, int totalNumbers)
        {
            long win = 1;
            for(int i=totalNumbers;i>totalNumbers - luckyNumbers; i--)
            {
                win *= i;
                win /= (totalNumbers - i + 1);
            }
            return win;
        }
    }
}
