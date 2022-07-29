using System;
using System.Collections;
using System.Collections.Generic;

namespace GameElements
{
    internal sealed class GenericDictionary : IEnumerable<object>
    {
        private readonly Dictionary<Type, object> itemMap;

        internal GenericDictionary()
        {
            this.itemMap = new Dictionary<Type, object>();
        }

        internal bool Add(object item)
        {
            var type = item.GetType();
            if (this.itemMap.ContainsKey(type))
            {
                return false;
            }

            this.itemMap.Add(type, item);
            return true;
        }

        internal bool Remove(object item)
        {
            var type = item.GetType();
            if (!this.itemMap.Remove(type))
            {
                return false;
            }

            return true;
        }

        internal T Get<T>()
        {
            var requiredType = typeof(T);
            if (this.itemMap.TryGetValue(requiredType, out var item))
            {
                return (T) item;
            }
            
            foreach (var pair in this.itemMap)
            {
                if (pair.Value is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Item of type {requiredType.Name} is not found!");
        }

        internal IEnumerable<T> All<T>()
        {
            foreach (var pair in this.itemMap)
            {
                if (pair.Value is T tElement)
                {
                    yield return tElement;
                }
            }
        }

        internal bool TryGet<T>(out T item)
        {
            var requiredType = typeof(T);
            if (this.itemMap.TryGetValue(requiredType, out var value))
            {
                item = (T) value;
                return true;
            }

            foreach (var pair in this.itemMap)
            {
                if (pair.Value is T result)
                {
                    item = result;
                    return true;
                }
            }

            item = default;
            return false;
        }

        public IEnumerator<object> GetEnumerator()
        {
            foreach (var pair in this.itemMap)
            {
                yield return pair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}