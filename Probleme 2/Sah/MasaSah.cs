using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sah
{
    [TestClass]
    public class MasaSah
    {
        [TestMethod]
        public void TestChess()
        {
            Assert.AreEqual(ChessBoard(2), 5);
            Assert.AreEqual(ChessBoard(8), 204);
        }
        int ChessBoard(int lengthTable)
        {
            int numberOfCubes = 0;
            for (int i = 1; i <= lengthTable; i++)
            {
                numberOfCubes += (int)Math.Pow(i, 2);            
            }
            return numberOfCubes;
        }
    }
}
