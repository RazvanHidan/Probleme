using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TerenulFermierului
{
    [TestClass]
    public class TetstFarm
    {
        [TestMethod]
        public void TestSurface()
        {
            Assert.AreEqual(ReturnInitialLength(57000, 230), 150);
            Assert.AreEqual(ReturnInitialLength(770000, 230), 770);
        }

        int CalculateSurface(int length, int width)
            {
            return length * width;
            }
        int ReturnInitialLength(int surface, int addedWidth)
        {

            double delta = (Math.Pow(addedWidth, 2) + (4 * surface));
            int initial = (int)(Math.Sqrt(delta)  - addedWidth)/2;
            return initial;
        }
    }
}
