using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ArrayDynamic
    {
        [TestMethod]
        public void AddNewMemberTest()
        {
            DynamicArray array = new DynamicArray();
            array.Add(7);
            Assert.AreEqual(array .LengthArray(), 1);
            array.Add(1);
            array.Add(5);
            Assert.AreEqual(array.LengthArray(), 3);
        }
        public class DynamicArray
        {
            private int[] elements;
            public DynamicArray()
            {
                elements = new int[0];
            }
            public int LengthArray()
            {
                return elements.Length;
            }
            public void Add(int newElement)
            {
                Array.Resize(ref elements, elements.Length + 1);
                elements[elements.Length - 1] = newElement;
            }
        }
    }
}
