using System;
using System.Collections;

namespace HashTable
{
    public class Library
    {
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
            keys[count] = value;
            buckets[HashFunction(value)] = value;
            count++;
        }

        private int HashFunction(string value)
        {
            int result;
            foreach (char c in value)
                result += c;
            return (result%(buckets.Length-1));
        }

        private void GenerateArray()
        {
            keys = new string [25];
            buckets = new string [25];
        }
    }
}