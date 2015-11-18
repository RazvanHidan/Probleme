using System;
using System.Collections;

namespace HashTable
{
    public class Library
    {
        private string book;
        public string[] keys;
        public string[] buckets;
        private int count;
        public Library()
        {
            keys = null;
            buckets = null;
            count = 0;
        }

        public void Add(string value)
        {
            if (count == 0)
                GenerateArray();
        }

        private void GenerateArray()
        {
            keys = new Array[25];
            buckets = new Array[25];
        }
    }
}