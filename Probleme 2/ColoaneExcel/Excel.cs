using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColoaneExcel
{
    [TestClass]
    public class Excel
    {
        [TestMethod]
        public void TestExcel1Letter()
        {
            Assert.AreEqual("Z", Convert (26));
            Assert.AreEqual("A", Convert(1));
        }
        [TestMethod]
        public void TestExcel2Letter()
        {
            Assert.AreEqual("AA", Convert(27));
            Assert.AreEqual("ZZ", Convert(702));
            Assert.AreEqual("ZA", Convert(677));
            Assert.AreEqual("AZ", Convert(52));
            Assert.AreEqual("BC", Convert(55));
            Assert.AreEqual("YA", Convert(651));
        }
        [TestMethod]
        public void TestExcel3Letter()
        {
            Assert.AreEqual("AAA", Convert(703));
            Assert.AreEqual("AAZ", Convert(728));
            Assert.AreEqual("ABC", Convert(731));
        }
        string addLetterFromAscii(string word,int codAscii)
        {
            return ((char)codAscii + word);
        }
        string Convert(int numberOfColum)
        {
            string constructWord = "";
            int cellNumber = numberOfColum;
            while (cellNumber >26)
            {
                if (cellNumber % 26 == 0)
                {
                    constructWord = "Z" + constructWord;
                    cellNumber = (cellNumber - 1) / 26;
                }
                else
                {
                    constructWord = (char)((cellNumber % 26) + 64) + constructWord;
                    cellNumber = (cellNumber / 26);
                }
            }
            constructWord = (char)((cellNumber % 27) + 64) + constructWord;
            return constructWord;
        }
    }
}
