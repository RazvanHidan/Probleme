using System;
using System.Collections;

namespace HashTableII
{
    public interface IHasher<in T>
    {
        int GetHashCode(T obj);
    }

    public struct Bucket<TKey, Tvalue>
    {
        TKey key;
        Tvalue value;
        int next;
        
        public Bucket(TKey key,Tvalue value,int next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }
    } 

    public class Hashtable<Tkey, Tvalue>:IHasher<Tkey>
    {
        private int[] keys;
        private Bucket<Tkey, Tvalue>[] buckets;
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

        public void Add(Tkey key, Tvalue value)
        {
            count++;
            var position = GetHashCode(key);
            int next = keys[position] == 0 ? -1 : keys[position];
            buckets[count] = new Bucket<Tkey, Tvalue>(key, value, next);
            keys[position] = count;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        private int GetHashCode(Tkey obj)
        {
            return Math.Abs(obj.GetHashCode() % keys.Length);
        }

        int IHasher<Tkey>.GetHashCode(Tkey obj)
        {
            throw new NotImplementedException();
        }
    }
}