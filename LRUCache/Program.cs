namespace LRUCache
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //["LRUCache","put","put","get","put","get","put","get","get","get"]

            var cache = new LRUCache.LinkedHashMap.Optimised.LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);
            cache.Put(3, 3);
            cache.Get(2);
            cache.Put(4, 4);
            cache.Get(1);
            cache.Get(3);
            cache.Get(4);
        }
    }
}

namespace LRUCache.LinkedHashMap.Optimised
{
    using System.Collections.Generic;

    public class CacheItem
    {
        public int Key { get; set; }
        public int Value { get; set; }
    }

    public class LRUCache
    {
        private readonly int capacity;
        private readonly LinkedList<CacheItem> lru;
        private readonly IDictionary<int, LinkedListNode<CacheItem>> cache;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.lru = new LinkedList<CacheItem>();
            this.cache = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
        }

        public int Get(int key)
        {
            // If found return object else return -1

            if (!this.cache.ContainsKey(key))
            {
                return -1;
            }

            var node = this.cache[key];
            var item = node.Value;

            this.lru.Remove(node);
            this.lru.AddFirst(node);

            return item.Value;
        }

        public void Put(int key, int value)
        {
            if (this.cache.ContainsKey(key))
            {
                var node = this.cache[key];
                var item = node.Value;
                item.Value = value;

                this.lru.Remove(node);
                this.lru.AddFirst(node);

                return;
            }

            this.EnsureCapacity();

            this.lru.AddFirst(new CacheItem { Key = key, Value = value });

            this.cache[key] = this.lru.First;
        }

        private void EnsureCapacity()
        {
            if (this.cache.Keys.Count + 1 > this.capacity)
            {
                var node = this.lru.Last;
                this.cache.Remove(node.Value.Key);
                this.lru.RemoveLast();
            }
        }
    }
}