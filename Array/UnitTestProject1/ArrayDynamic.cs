﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ArrayDynamic
    {
        [TestMethod]
        public void AddNewElement()
        {
            DynamicArray array = new DynamicArray();
            array.Add(7);
            Assert.AreEqual(array .LengthArray(), 1);
            array.Add(1);
            array.Add(5);
            Assert.AreEqual(array.LengthArray(), 3);
        }
        [TestMethod]
        public void InsertNewElemennt()
        {
            DynamicArray array = new DynamicArray();
            array.Add(7);
            array.Insert(1, 1);
            Assert.AreEqual(array.LengthArray(), 2);
            array.Insert(5, 2);
            Assert.AreEqual(array.LengthArray(), 3);
            array.Insert(6, 2);
            Assert.AreEqual(array.LengthArray(), 4);
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

            private void IncreaseLength(int lengthAdd)
            {
                Array.Resize(ref elements, elements.Length + lengthAdd);
            }

            public void Add(int newElement)
            {
                IncreaseLength(1);
                elements[elements.Length - 1] = newElement;
            }

            public void Insert(int element, int position)
            {
                IncreaseLength(1);
                int aux;
                for (int i = position - 1; i < elements.Length; i++) 
                {
                    aux = elements[i];
                    elements[i] = element;
                    element = aux;
                }
            }
        }
    }
}
