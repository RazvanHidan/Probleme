using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace ConstructDynamicArray
{
    [TestClass]
    public class ArrayDynamic
    {
        [TestMethod]
        public void AddNewElement()
        {
            DynamicArray array = new DynamicArray();
            array.Add(7);
            Assert.AreEqual(array .GetCount(), 1);
            array.Add(1);
            array.Add(5);
            Assert.AreEqual(array.GetCount(), 3);
        }
        [TestMethod]
        public void InsertNewElemennt()
        {
            DynamicArray array = new DynamicArray();
            array.Add(7);
            array.Insert(1, 1);
            Assert.AreEqual(array.GetCount(), 2);
            array.Insert(5, 2);
            Assert.AreEqual(array.GetCount(), 3);
            array.Insert(6, 2);
            Assert.AreEqual(array.GetCount(), 4);
        }
        [TestMethod]
        public void DeleteElemennt()
        {
            DynamicArray array = new DynamicArray();
            array.Add(7);
            array.Delete(1);
            Assert.AreEqual(array.GetCount(), 0);
            array.Add(1);
            array.Add(4);
            array.Delete(2);
            Assert.AreEqual(array.GetCount(), 1);
            array.Add(2);
            array.Add(8);
            array.Add(7);
            array.Delete(2);
            Assert.AreEqual(array.GetCount(), 3);
            array.Add(6);
            array.Add(1);
            array.Add(9);
            array.Delete(1);
            Assert.AreEqual(array.GetCount(), 5);
        }
        [TestMethod]
        public void GetValueOfPosition()
        {
            DynamicArray array = new DynamicArray();
            array.Add(7);
            array.Add(1);
            array.Add(4);
            array.Add(2);
            array.Add(8);
            array.Add(7);
            Assert.AreEqual(array.GetElementAt(1), 7);
            Assert.AreEqual(array.GetElementAt(-1), 0);
            Assert.AreEqual(array.GetElementAt(12), 0);
        }
        [TestMethod]
        public void GetCount()
        {
            DynamicArray array = new DynamicArray();
            Assert.AreEqual(array.GetCount(), 0);
            array.Add(7);
            Assert.AreEqual(array.GetCount(), 1);
            array.Delete(1);
            Assert.AreEqual(array.GetCount(), 0);
            array.Add(4);
            array.Add(2);
            array.Add(8);
            array.Add(7);
            array.Add(4);
            array.Add(2);
            array.Add(8);
            array.Add(7);
            array.Add(7);
            Assert.AreEqual(array.GetCount(), 9);
        }
        [TestMethod]
        public void InsertNewArray()
        {
            var addArray = new int[] { 1, 3, 5, 7, 10, 2, 5, 3,43 };
            DynamicArray array = new DynamicArray();
            array.AddArray(addArray, 1);
            Assert.AreEqual(array.GetCount(), 9);
            var newArray = new int[] { 0, 1, 0, 1 };
            array.AddArray(newArray, 3);
            Assert.AreEqual(array.GetCount(), 13);
        }
        [TestMethod]
        public void IEnumerable_ReturnELement()
        {
            var addArray = new int[] { 1, 3, 5, 7, 10, 2, 5, 3, 43 };
            DynamicArray array = new DynamicArray();
            array.AddArray(addArray, 1);
            Assert.AreEqual(array.ReturnElement  (5), 10);
            Assert.AreEqual(array.ReturnElement (2), 3);
        }
        public class DynamicArray:IEnumerable 
        {
            private int[] elements;
            private int count;
            
            
            public DynamicArray()
            {
                elements = new int[0];
                count = 0;
            }

            public IEnumerator GetEnumerator()
            {
                int stop = 0;
                foreach (var number in elements)
                {
                    if (stop == count)
                        break;
                    stop++;
                    yield return number;
                }
            }

            public int ReturnElement(int position)
            {
                int result = 0;
                int index = 0;
                var enumerator = GetEnumerator();
                while(enumerator .MoveNext())
                {
                    index++;
                    if (index == position)
                    {
                        result = (int)enumerator.Current;
                    }   
                }
                return result;
            }

            public int GetCount()
            {
                return count;
            }

            private void IncreaseLength(int lengthAdd)
            {
                if (lengthAdd < 0)
                    count += lengthAdd;
                else
                {
                    while(elements.Length < count + lengthAdd)
                        Array.Resize(ref elements, elements.Length + 8);
                    count += lengthAdd;
                }
            }

            public void Add(int newElement)
            {
                IncreaseLength(1);
                elements[count - 1] = newElement;
            }

            public void Insert(int element, int position)
            {
                IncreaseLength(1);
                int aux;
                for (int i = position - 1; i < count; i++) 
                {
                    aux = elements[i];
                    elements[i] = element;
                    element = aux;
                }
            }

            public void Delete(int deletePosition)
            {
                if (!((deletePosition == count) || (count == 1)))
                    for (int i = deletePosition - 1; i < count - 1; i++) 
                        elements[i] = elements[i + 1];
                IncreaseLength(-1);
            }

            public int GetElementAt(int position)
            {
                if ((position < count + 1) && (position > 0)) 
                    return elements[position-1];
                return 0;
            }

            public void AddArray(int[] addArray,int position)
            {
                for (int j = addArray.Length - 1; !(j < 0); j--) 
                    Insert(addArray[j], position);
            }
        }
    }
}
