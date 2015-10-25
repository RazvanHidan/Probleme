using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pascal
{
    [TestClass]
    public class PascalTriangle
    {
        [TestMethod]
        public void TestPascal()
        {
            Assert.AreEqual("1 4 6 4 1 ",ConvertToString ( Pascal(5)));
        }
        int[] Step(int[] level)
        {
            var newlevel = new int[level.Length + 1];
            newlevel[0] = 1;
            newlevel[newlevel.Length - 1] = 1;
            for(int i=1; i<newlevel.Length - 1; i++)
            {
                newlevel[i] = level[i - 1] + level[i];
            }
            return newlevel;
        }
        int[] level12(int numberOfelement)
        {
            var array = new int[numberOfelement];
            for (int i = 0; i < numberOfelement; i++)
                array[i] = 1;
            return array;
        }
        int[] Pascal(int level)
        {
            if (level == 1)
                return level12(1);
            if (level == 2)
                return level12(2);
            return Step(Pascal(level -1));
        }
        string ConvertToString(int[] array)
        {
            string level = "";
            for (int i = 0; i < array.Length; i++)
                level += array[i].ToString ()+" ";
            return level;
        }
    }
}
