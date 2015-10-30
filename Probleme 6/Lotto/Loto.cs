using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lotto
{
    [TestClass]
    public class Loto
    {
        [TestMethod]
        public void Test2Lotto()
        {
            int[] x = new int[8] { 1,5,2,9,4,3,6,10 };
            Assert.AreEqual("1 2 3 4 5 6 9 10", LottoNumbers(x));
        }
        void Insert(ref int[] array, int positions,int value)
        {
            Array.Resize(ref array, array.Length + 1);
            int aux = array [positions];
            array[positions] = value;
            for (int i=positions+1;i<array.Length; i++)
            {
                value = array[i];
                array[i] = aux;
                aux = value;
            }
        }
        string LottoNumbers(int[] numbers)
        {
            var result = new int[1];
            result[0] = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                int j = 0;
                while ((j != (result.Length )) && (numbers[i] > result[j])) 
                {
                    j++;
                }
                Insert(ref result, j, numbers[i]);
            }
            string dispay = String.Join(" ", result);
            return dispay;    
        }
    }
}
