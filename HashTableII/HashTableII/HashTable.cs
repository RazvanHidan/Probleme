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
            return BucketPositionKey(key) != 0 ? true : false;
        }

        public void Remove(Tkey key)
        {
            var bucketKey = BucketPositionKey(key);
            if (bucketKey!= 0)
            {
                int code = GetHashCode(key);
                int firstKey = keys[code];
                if (buckets[firstKey].next == -1)
                {
                    keys[code] = 0;
                }
                else if (buckets[firstKey].key.CompareTo(key)==0) 
                {
                    keys[code] = buckets[firstKey].next;
                }
                else
                {
                    int step = keys[code];
                    while (buckets[step].next != bucketKey)
                    {
                        step = buckets[step].next;
                    }
                    buckets[step].next = buckets[bucketKey].next;
                }
                buckets[bucketKey] = buckets[0];
                numberOfElement--;
            }
        }

        public Tvalue this[Tkey key]
        {
            get
            {
                return BucketPositionKey(key) != 0 ? buckets[BucketPositionKey(key)].value : default(Tvalue);
            }
            set
            {
                buckets[BucketPositionKey(key)].value = BucketPositionKey(key) != 0 ? value : default(Tvalue);
            }
        }

        public int Count
        {
            get
            {
                return numberOfElement;
            }
        }

        private int BucketPositionKey(Tkey key)
        {
            var index = GetHashCode(key);
            if (keys[index] != 0)
            {
                index = keys[index];
                while (index != -1)
                {
                    if (key.CompareTo(buckets[index].key) == 0)
                        return index;
                    index = buckets[index].next;
                }
            }
            return 0;
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