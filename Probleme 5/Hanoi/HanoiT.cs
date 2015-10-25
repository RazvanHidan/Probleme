using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hanoi
{
    [TestClass]
    public class HanoiT
    {
        [TestMethod]
        public void TestHanoi()
        {
            int number = 8;
            int[] from = new int[0];
            int[] to = new int[0];
            int[] aux = new int[0];
            Initialization(number, ref from);
            int k = 0;
            Assert.AreEqual(Hanoi(number, ref from, ref to, ref aux, ref k), 255);
        }
        void Initialization(int n, ref int[] from)
        {
            Array.Resize(ref from, n);
            for (int i = 0; i < from.Length; i++)
                from[i] = i + 1;
        }
        void DiscMove(ref int[] from,ref int[] to)
        {
            Array.Resize(ref to, to.Length + 1);
            to[to.Length - 1] = from[from.Length - 1];
            Array.Resize(ref from, from.Length - 1);
        }
        int Hanoi(int discNumber,ref int[] from,ref int[] to,ref int[] aux,ref int count)
        {

            if (discNumber == 1)
            {
                DiscMove(ref from, ref to);
                count++;
            }
            else
            {
                Hanoi(discNumber - 1,ref from,ref aux,ref to,ref count);
                count++;
                DiscMove(ref from, ref to);
                Hanoi(discNumber - 1,ref aux,ref to,ref from,ref count);        
            }
            return count;
        }
    }
}
