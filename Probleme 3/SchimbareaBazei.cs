using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchimbareBaza
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConvertToString()
        {
            Assert.AreEqual( "1111011", ReturnString(ConvertBase(123, 2)));
            Assert.AreEqual("11100111", ReturnString(ConvertBase(231, 2)));
        }
        [TestMethod]
        public void TestConvertToNumber()
        {
            Assert.AreEqual((ReturnNumber(ConvertBase(123, 2))), 1111011);
        }
        [TestMethod]
        public void TestAND()
        {
            Assert.AreEqual("1100011", ReturnString(AND (ConvertBase (123,2),(ConvertBase (231,2)))));

        }
        [TestMethod]
        public void TestOR()
        {
            Assert.AreEqual("1111111", ReturnString(OR(ConvertBase(123, 2), (ConvertBase(231, 2)))));

        }
        [TestMethod]
        public void TestXOR()
        {
            Assert.AreEqual("11100", ReturnString(XOR(ConvertBase(123, 2), (ConvertBase(231, 2)))));

        }
        [TestMethod]
        public void TestNOT()
        {
            Assert.AreEqual("100", (ReturnString(NOT(ConvertBase(123, 2)))));
        }
        [TestMethod]
        public void TestSUM()
        {
            Assert.AreEqual(ReturnNumber(SUM((ConvertBase(175, 2)),(ConvertBase(27, 2)), 2)), 11001010);
            Assert.AreEqual(ReturnNumber(SUM((ConvertBase(62, 5)),(ConvertBase(452, 5)), 5)), 4024);
        }
        [TestMethod]
        public void TestDIF()
        {
            Assert.AreEqual(ReturnNumber(DIF((ConvertBase(2, 2)), (ConvertBase(1, 2)), 2)), 1);
            Assert.AreEqual(ReturnNumber(DIF((ConvertBase(128, 6)), (ConvertBase(21, 6)), 6)), 255);
        }
        [TestMethod]
        public void TestLeft()
        {
            Assert.AreEqual(ReturnNumber(MoveLeft(ConvertBase (10,2))), 100);
            Assert.AreEqual(ReturnNumber(MoveLeft(ConvertBase(123, 2))), 1110110);
        }
        [TestMethod]
        public void TestRight()
        {
            Assert.AreEqual(ReturnNumber(MoveRight(ConvertBase(10, 2))), 101);
            Assert.AreEqual(ReturnNumber(MoveRight(ConvertBase(123, 2))), 111101);
        }
        [TestMethod]
        public void TestCompare()
        {
            Assert.AreEqual((Compare((ConvertBase(175, 2)), (ConvertBase(27, 2)))), 1);
            Assert.AreEqual((Compare((ConvertBase(175, 2)), (ConvertBase(176, 2)))), -1);
            Assert.AreEqual((Compare((ConvertBase(13, 2)), (ConvertBase(11, 2)))), 1);
            Assert.AreEqual((Compare((ConvertBase(43, 2)), (ConvertBase(43, 2)))), 0);
        }

        void UpSize(ref byte[] array)
        {
            Array.Resize(ref array, array.Length + 1);
        }
        byte[] ConvertBase(int number, int toBase)
        {
            byte[] newBase = new byte[0];
            int div = number;
            for (int i = 0; div != 0; i++)
            {
                UpSize(ref newBase);
                newBase[i] = (byte)(div % toBase);
                div /= toBase;
            }
            return newBase;
        }

        string ReturnString(byte[] array)
        {
            Array.Reverse(array);
            string s = string.Join("", array);
            return s;
        }
        int ReturnNumber(byte[] array)
        {
            int number = 0;
            for (int i = 0; i != array.Length ; i++)
            {
                number += (int)(array[i] * Math.Pow(10, i));
            }
            return number;
        }
        bool CompareEquality(byte left, byte right)
        {
            return left == right ? true : false;
        }
        byte[] ChooseOperation(byte[] firstArray,byte[] secondArray,int option)
        {
            byte[] result = new byte[0];
            for (int i=0;i!=Math.Min (firstArray .Length ,secondArray .Length); i++)
            {
                UpSize(ref result);
                switch (option)
                {
                    case 1://AND
                        result[i]= (byte)(((firstArray [i] == 1)&&(secondArray [i]==1)) ? 1 : 0);  
                        break ;
                    case 2://OR
                        result[i] = (byte)(((firstArray[i] == 1) || (secondArray[i] == 1)) ? 1 : 0); 
                        break;
                    case 3://XOR
                        result[i] = (byte)(((firstArray[i] == 1) != (secondArray[i] == 1)) ? 1 : 0);
                        break;
                }
            }
            ElminitateNull(ref result);
            return result;
        }
        void ElminitateNull(ref byte[] array)
        {
            for(int i = array.Length-1; i > 0; i--)
            {
                if (array[i] != 0)
                {
                    Array.Resize(ref array, i+1);
                    return;
                }
            }
        }

        byte[] AND(byte[] first,byte[] second)
        {
            return ChooseOperation(first, second, 1);
        }
        byte[] OR(byte[] first, byte[] second)
        {
            return ChooseOperation(first, second, 2);
        }
        byte[] XOR(byte[] first, byte[] second)
        {
            return ChooseOperation(first, second, 3);
        }
        byte[] NOT(byte[] array)
        {
            byte[] result = new byte[array.Length];
            for (int i = 0; i != array .Length; i++)
            {
                result[i] =(byte)( array[i] == 1 ? 0 : 1);
            }
            ElminitateNull(ref result);
            return result;
        }

        void EqualsArraysLength(ref byte[] first,ref byte[] second)
        {
            Array.Resize(ref first ,Math .Max (first .Length ,second .Length ));
            Array.Resize(ref second , Math.Max(first.Length, second.Length));
        }
        byte[] SUM(byte[] first, byte[] second,int numbersBase)
        {
            EqualsArraysLength(ref first, ref second);
            byte r = 0;
            byte[] result = new byte[first.Length];
            for (int i = 0; i!=result.Length; i++)
            {
                result[i] = (byte)((first[i] + second[i] + r) % numbersBase);
                r = (byte)((first[i] + second[i] + r) / numbersBase);
            }
            UpSize(ref result);
            result[result.Length-1] = r;
            ElminitateNull(ref result);
            return result;
        }
        byte[] DIF(byte[] first, byte[] second,int numbersBase)
        {
            EqualsArraysLength(ref first, ref second);
            byte r = 0;
            byte[] result = new byte[first.Length];
            for (int i = 0; i != result.Length; i++)
            {
                result[i] = (byte)((numbersBase + first[i] - second[i]-r) % numbersBase);
                r = (byte)(((first[i] - second[i] - r) < 0) ? 1 : 0);
            }
            ElminitateNull(ref result);
            return result;
        }
        void LeftShift(ref byte[] left)
        {
            for (int i = left.Length -2; i >=0; i--)
            {
                left[i+1] = left[i];
            }
            left[0] = 0;
            ElminitateNull(ref left);
        }
        void RightShift(ref byte[] right)
        {
            for (int i = 0; i<=right.Length-2; i++)
            {
                right[i] = right[i + 1];
            }
            right[right.Length-1] = 0;
            ElminitateNull(ref right);
        }
        byte[] MoveLeft(byte[] array)
        {
            LeftShift(ref array);
            return array;
        }
        byte[] MoveRight(byte[] array)
        {
            RightShift(ref array);
            return array;
        }
        int Compare(byte[] first,byte[] second)
        {
            int answerCompare = 0;
            if (first.Length < second.Length)
                answerCompare = -1;
            else
            {
                EqualsArraysLength(ref first, ref second);
                for (int i = first.Length - 1; i >= 0; i--)
                {
                    if (first[i] < second[i])
                        return answerCompare = -1;
                    else if (first[i] > second[i])
                        return answerCompare = 1;
                }
            }
            return answerCompare;
            //LessThan retrun=-1
            //GraterThan return=1
            //Equal return =0
            //NotEqual retrun!=0
        }
    }
}
