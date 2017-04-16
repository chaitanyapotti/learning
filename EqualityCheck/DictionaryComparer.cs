using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCheck
{
    internal class DictionaryComparer : IDictionary<string, int>
    {
        private Dictionary<string, int> dict;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, int> item)
        {
            dict.Add(item.Key, item.Value);
            //throw new NotImplementedException();
        }

        public void Clear()
        {
            dict.Clear();
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, int> item)
        {
           return  dict.Contains(item);
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, int>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, int> item)
        {
            return dict.Remove(item.Key);
            //throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, int value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out int value)
        {
            throw new NotImplementedException();
        }

        public int this[string key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ICollection<string> Keys { get; }
        public ICollection<int> Values { get; }

       
    }
}
