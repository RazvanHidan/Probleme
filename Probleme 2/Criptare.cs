using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criptare
{
    [TestClass]
    public class Coded
    {
        [TestMethod]
        public void TestCodBound()
        {
            Assert.AreEqual("neeaircsciaaanaqiucq",EncodingMessage  ( "nicaieri nu e ca acasa",4));
        }
        void BoundMessage(ref string message)
        {
            message = message.Replace(" ", "");
        }
        void AddCode(ref string message, int numberOfColumns)
        {
            BoundMessage(ref message);
            int add = numberOfColumns -(int)Math.Ceiling((double)(message.Length % numberOfColumns));
            for (int i = 1 ; i<=add; i++)
                message = message + "q";
        }
        string EncodingMessage(string message,int numberOfColumns)
        {
            AddCode(ref message, numberOfColumns);
            string codedMessage = "";
            int numberOfRow = message.Length / numberOfColumns;
            for (int i=0;i!=numberOfRow ; i++)
                for(int j=0;j!=numberOfColumns; j++)
                {
                    codedMessage += message[i + (j * numberOfRow)];
                }
            return codedMessage;
        }
    }
}
