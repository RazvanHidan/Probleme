using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cub
{
    [TestClass]
    public class Cub
    {
        [TestMethod]
        public void TestCub()
        {
            Assert.AreEqual(Contor (2),442);
            Assert.AreEqual(Contor(1), 192);
            Assert.AreEqual(Contor(3), 692);
        }
        int CubNumber(int number)
        {
            return (number * number * number);
        }
        bool ValidateTermination888(int number)
        {
            if ( CubNumber (number )%1000 == 888)
            {
                return true;
            }
            else return false;
        }
        int Contor(int k)
        {
            int i = 0;
            int number;
            for (number=2;i!= k;number+=2)
            {
                if (Math.Pow(number, 3) % 1000 == 888)
                    i++;
            }
            return number-2;       
        }
    }
}
