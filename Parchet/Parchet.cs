using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parchet
{
    [TestClass]
    public class Parchet
    {
        [TestMethod]
        public void TestNumberPieces()
        {
            Assert.AreEqual(NumberPieces(5, 4, 2, 2), 6);
            Assert.AreEqual(NumberPieces(4, 4, 2, 2), 5);
        }
        int NumberPieces(int length, int width, int lengthPiece, int widthPiece)
        {
            return (int)Math.Ceiling((length * width) / (lengthPiece * widthPiece * 0.85));
        }
    }
}
