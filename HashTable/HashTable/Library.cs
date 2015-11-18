using System;
using System.Collections;

namespace HashTable
{
    public class Bucket
    {
        public string value;
        public Bucket next;

        public Bucket(string value)
        {
            this.value = value;
            next = null;
        }
    }

    public class Library
    {
        public string[] keys;
        public Bucket[] entry;
        private int count;
        public Library()
        {
            keys = null;
            entry = null;
            count = 0;
        }

        public void Add(string value)
        {
            if (count == 0)
                GenerateArray();
            keys[count] = value;

            var index = HashFunction(value);
            AddEntry(value, index);
            count++;
        }

        private void AddEntry(string value, int index)
        {
            if (entry[index] == null)
                entry[index] = new Bucket(value);
            else
                entry[index].next = new Bucket(value);
        }

        private int HashFunction(string value)
        {
            int result = 0;
            foreach (char c in value)
                result += c;
            return (result%(entry.Length-1));
        }

        private void GenerateArray()
        {
            keys = new string [25];
            entry = new Bucket [25];
        }
    }
}