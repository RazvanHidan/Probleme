using System;
using System.Collections;

namespace HashTableII
{
    public interface IHasher<in T>
    {
        int GetHashCode(T obj);
    }

    public struct Bucket<key, value>
    {
        key keyValue;
        value infoKey;
        int next
        {
            get
            {
                return -1;
            }
        }
    } 

    public class Hashtable<key, value>:IHasher<key>
    {
        private key keyValue;
        private int[] keys;
        private Bucket<key, value>[] buckets;
        private int count;

        public Hashtable()
        {
            keys = null;
            buckets = null;
            count = 0;
        }

        public Hashtable(int capacity)
        {
            Array.Resize(ref keys, capacity);
            Array.Resize(ref buckets, capacity);
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        private int GetHashCode(key obj)
        {
            throw new NotImplementedException();
        }

        int IHasher<key>.GetHashCode(key obj)
        {
            throw new NotImplementedException();
        }
    }
}