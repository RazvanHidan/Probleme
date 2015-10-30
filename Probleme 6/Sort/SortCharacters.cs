using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sort
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1UP()
        {
            Assert.AreEqual("abcdef", SortAscending("ac db fe"));
            Assert.AreEqual("A", SortAscending("A"));
        }
        [TestMethod]
        public void Test1DOWN()
        {
            Assert.AreEqual("fedcba", SortDescending("ac db fe"));
        }

        void RemoveSpace(ref string array)
        {          
            array = array.Replace(" ", "");
        }
        void Swap(ref char first,ref char second)
        {
            char aux;
            aux = first;
            first = second;
            second = aux;
        }
        char[] Convert(string array)
        {
            RemoveSpace(ref array);
            char[] elements = array.ToCharArray();
            return elements;
        }
        string SortAscending(string array)
        {
            char[] elements = Convert(array);
            int i = 0;
            while (i < elements.Length - 1)
            {
                if (elements[i] > elements[i + 1])
                {
                    Swap(ref elements[i], ref elements[i + 1]);
                    i = 0;
                }
                else i++;
            }
            string result = new string(elements);
            return result;
        }
        string SortDescending(string array)
        {
            char[] element = Convert(array);
            int i = 0;
            while(i<element .Length -1)
            {
                if (element[i] < element[i + 1])
                {
                    Swap(ref element[i], ref element[i + 1]);
                    i = 0;
                }
                else i++;
            }
            string result = new string(element);
            return result;
        }
    }
}
