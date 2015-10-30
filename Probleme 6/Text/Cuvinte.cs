using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Text
{
    [TestClass]
    public class Cuvinte
    {
        [TestMethod]
        public void Test4Text()
        {
            Assert.AreEqual("are nu mere ana ", Sort("nu mere ana mere nu ana ana ana are mere"));
        }
        public struct Elements
        {
            public string word;
            public int numberOfApparition;
        }
        void AddElement(ref Elements[] pozitie, string add)
        {
            Array.Resize(ref pozitie , pozitie .Length + 1);
            pozitie[pozitie.Length - 1].word = add;
            pozitie[pozitie.Length - 1].numberOfApparition = 1;
        }
        Elements[] Construct(string text)
        {
            string[] cuv = text.Split(' ');
            var app = new Elements[0];
            var help = new string[0];
            for (int i = 0; i < cuv.Length; i++)
            {
                int j = 0;
                while ((j != (app.Length)) && (cuv[i] !=app[j].word ))
                {
                    j++;
                }
                if(j==app.Length )
                    AddElement(ref app, cuv[i]);
                else
                    app[j].numberOfApparition++;
            }
            return app;         
        }
        string Sort(string text)
        {
            var array = Construct(text);
            int start = 0;
            int stop = array.Length-1;
            QuickSort (ref array,start,stop);
            string result = "";
            for (int i = 0; i < array.Length ; i++)
                result += array[i].word+" ";
            return result;
        }
        void Swap(ref Elements  first, ref Elements  second)
        {
            Elements aux;
            aux = first;
            first = second;
            second = aux;
        }

        void QuickSort(ref Elements[] array, int start, int stop)
        {
            int i = start;
            int j = stop;
            int pivot = array[(i + j) / 2].numberOfApparition;
            while (i <= j)
            {
                while (array[i].numberOfApparition.CompareTo(pivot) < 0)
                    i++;
                while (array[j].numberOfApparition.CompareTo(pivot) > 0)
                    j--;
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;j--;
                }
            }
            if (start < j)
                QuickSort(ref array, start, j);
            if (stop > i)
                QuickSort(ref array, i, stop);
        }
    }
}