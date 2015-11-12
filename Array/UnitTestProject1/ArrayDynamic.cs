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
            DynamicArray<int> array = new DynamicArray<int>();
            array.Add(7);
            Assert.AreEqual(array .GetCount(), 1);
            array.Add(1);
            array.Add(5);
            Assert.AreEqual(array.GetCount(), 3);
        }
        [TestMethod]
        public void InsertNewElemennt()
        {
            DynamicArray<int> array = new DynamicArray<int>();
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
            DynamicArray<int> array = new DynamicArray<int>();
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
            DynamicArray<int> array = new DynamicArray<int>();
            array.Add(7);
            array.Add(1);
            array.Add(4);
            array.Add(2);
            array.Add(8);
            array.Add(7);
            Assert.AreEqual(array[1], 1);
            Assert.AreEqual(array[3], 2);
        }
        [TestMethod]
        public void GetCount()
        {
            DynamicArray<int> array = new DynamicArray<int>();
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
            DynamicArray<int> array = new DynamicArray<int>();
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
            DynamicArray<int> array = new DynamicArray<int>();
            array.AddArray(addArray, 1);
            Assert.AreEqual(array.ReturnElement  (5), 10);
            Assert.AreEqual(array.ReturnElement (2), 3);
        }
        [TestMethod]
        public void Array_GenericType_String()
        {
            var addArray = new string[] {"RAzvan","Andrei","Ionut","Negrean","Sorin","Alin","Cristi","3","43" };
            DynamicArray<string> array = new DynamicArray<string>();
            array.AddArray(addArray, 1);
            Assert.AreEqual("Negrean",array.ReturnElement(4));
            Assert.AreEqual("3",array.ReturnElement(8));
        }

        public class ArrayEnumerator <T>:IEnumerator
        {
            public T[] element;
            public int index;

            public ArrayEnumerator(T[] element)
            {
                this.element = element;
                index = -1;
            }
            object IEnumerator.Current
            {
                get
                {
                    return element[index];
                }
            }
            
            public bool MoveNext()
            {
                if (index++ < element.Length )
                    return true;
                else return false;
            }
            
            public void Reset()
            {
                index =-1;
            }
        }
        public class DynamicArray<T>:IEnumerable 
        {
            private T[] elements;
            private int count;
            
            
            public DynamicArray()
            {
                elements = new T[0];
                count = 0;
            }

            public IEnumerator GetEnumerator()
            {

                return new ArrayEnumerator<T>(elements);
            }

            public T ReturnElement(int position)
            {
                T result=default(T);
                int index = 0;
                var enumerator = GetEnumerator();
                while(enumerator .MoveNext())
                {
                    index++;
                    if (index == position)
                    {
                        result = (T)enumerator.Current;
                        break;
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

            public void Add(T newElement)
            {
                IncreaseLength(1);
                elements[count - 1] = newElement;
            }

            public void Insert(T element, int position)
            {
                IncreaseLength(1);
                T aux;
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

            public T this[int position]
            {
                get
                {
                    return elements[position];
                }
                set
                {
                    elements[position] = value;
                }
            }

            public void AddArray(T[] addArray,int position)
            {
                for (int j = addArray.Length - 1; !(j < 0); j--) 
                    Insert(addArray[j], position);
            }
        }
    }
}
