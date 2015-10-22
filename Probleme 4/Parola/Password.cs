using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parola
{
    [TestClass]
    public class Password
    {
        [TestMethod]
        public void TestPassword()
        {
            Assert.AreEqual("random", PasswordGen (5, 3, 4, 2, 3));
        }
        void AddSymbols(ref string password, int elementAdd,string series)
        {
            var random = new Random();
            for (int i = 0; i < elementAdd; i++)
            {
                password += series[random.Next(series.Length)];
            }
        }
        void MixAll(ref string password, int length)
        {
            string mix = "";
            AddSymbols(ref mix, length, password);
            password = mix;
        }
        string PasswordGen(int length, int symbolsNr, int numbersNr, int lowercaseNr, int uppercaseNr)
        {
            const string symbols = "!@#$%^&*_+-=:?";
            const string numbers = "23456789";
            const string lowercase = "abcdefghijkmnpqrstuvxyz";
            const string uppercase = "ABCDEFGHIJKMNPQRSTUVXYZ";
            string password = "";
            AddSymbols(ref password, symbolsNr, symbols);
            AddSymbols(ref password, numbersNr, numbers);
            AddSymbols(ref password, lowercaseNr, lowercase);
            AddSymbols(ref password, uppercaseNr, uppercase);
            MixAll(ref password, length);
            return password;
        }
    }

}
