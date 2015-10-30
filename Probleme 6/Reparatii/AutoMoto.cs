using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reparatii
{
    [TestClass]
    public class AutoMoto
    {
        [TestMethod]
        public void Test3Auto()
        {
            Auto[] Moto = new Auto[5];
            Moto[0].situation = Priority.High;
            Moto[1].situation = Priority.Low;
            Moto[2].situation = Priority.High;
            Moto[3].situation = Priority.Medium;
            Moto[4].situation = Priority.Low;
            Moto[0].brand = "Audi";
            Moto[1].brand = "BMw";
            Moto[2].brand = "Opel";
            Moto[3].brand = "Dacia";
            Moto[4].brand = "Volvo";


            Assert.AreEqual("Audi Opel Dacia BMw Volvo ", Display(Moto));
        }

        public enum Priority:int
        {
            High = 1,
            Medium = 2,
            Low = 3
        }
        public struct Auto
        {
            public Priority situation;
            public string brand;
            public int year;
        }
        void SortShell(ref Auto [] array, int length)
        {
            int i;
            int j;
            int step = 3;
            Auto aux;
            while (step > 0)
            {
                for (i = 0; i < length; i++)
                {
                    j = i;
                    aux = array[i];
                    while ((j >= step) && (array[j - step].situation > aux.situation)) 
                    {
                        array[j] = array[j - step];
                        j = j - step;
                    }
                    array[j] = aux;
                }
                if (step / 2 != 0)
                    step = step / 2;
                else if (step == 1)
                    step = 0;
                else
                    step = 1;
            }
        }
        string Display(Auto [] array)
        {
            SortShell(ref array, array.Length);
            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i].brand + " ";
            return result;
        }
    }
}
