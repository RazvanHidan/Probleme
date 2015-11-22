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
        public TKey key;
        public Tvalue value;
        public int next;
        
        public Bucket(TKey key,Tvalue value,int next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }
    } 

    public class Hashtable<Tkey, Tvalue>:IHasher<Tkey>where Tkey:IComparable
    {
        private int[] keys;
        private Bucket<Tkey, Tvalue>[] buckets;
        private int count;
        private int numberOfElement;

        public Hashtable()
        {
            keys = null;
            buckets = null;
            count = 0;
            numberOfElement = 0;
        }

        public Hashtable(int capacity)
        {
            Array.Resize(ref keys, capacity);
            Array.Resize(ref buckets, capacity);
        }

        public void Add(Tkey key, Tvalue value)
        {
            count++;
            numberOfElement++;
            var position = GetHashCode(key);
            int next = keys[position] == 0 ? -1 : keys[position];
            buckets[count] = new Bucket<Tkey, Tvalue>(key, value, next);
            keys[position] = count;
        }

        public bool ContainsKey(Tkey key)
        {
            var index = GetHashCode(key);
            if (keys[index] != 0)
            {
                index = keys[index];
                while (index != -1)
                {
                    if (key.CompareTo(buckets[index].key) == 0)
                        return true;
                    index = buckets[index].next;
                }
            }
            return false;
        }

        public void Remove(Tkey key)
        {
            var index = GetHashCode(key);
            if (keys[index] != 0)
            {
                index = keys[index];
                int temp = 0;
                while (index != -1)
                {
                    if (key.CompareTo(buckets[index].key) == 0)
                    {
                        buckets[temp].next = buckets[index].next;
                        buckets[index] = buckets[0];
                        break;
                    }
                    temp = index;
                    index = buckets[index].next;
                }
            }
            numberOfElement--;
        }

        public int Count
        {
            get
            {
                return numberOfElement;
            }
        }

        private int GetHashCode(Tkey obj)
        {
            return 2;//Math.Abs(obj.GetHashCode() % keys.Length);
        }

        int IHasher<Tkey>.GetHashCode(Tkey obj)
        {
            throw new NotImplementedException();
        }
    }
}