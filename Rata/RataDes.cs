using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rata_descrescatoare
{
    [TestClass]
    public class Dobanda
    {
        [TestMethod]
        public void Total()
        {
            Assert.AreEqual(Debt(10000, 12, 10), 10541.67, 0.01);
        }
        [TestMethod]
        public void Pay()
        {
            Assert.AreEqual(Rate(10000, 12, 10, 2), 909.72, 0.01);
        }
        double Repeat(double a, double b, double c, double d)
        {
            return ((a / b / c) + d);
        }
        double Rate(double sum, int time, double gain, int months)
        {
            double i;
            i = sum / time * (months - 1);
            return Repeat(sum - i, gain, 12, sum / time);
        }


        double Debt(double sum, int time, double gain)
        {
            double remainingDebt = sum;
            double s = 0;
            int i = 0;
            while (i++ < time)
            {
                s = Repeat(remainingDebt, gain, 12, s);
                remainingDebt = remainingDebt - sum / time;
            }
            return s + sum;
        }
    }
}
