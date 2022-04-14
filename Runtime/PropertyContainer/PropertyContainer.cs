using SorceressSpell.LibrarIoh.Core;
using System.Collections;
using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Collections
{
    public class PropertyContainer<TValue> : IDictionary<string, TValue>, ICopyFrom<PropertyContainer<TValue>>
    {
        #region Fields

        protected readonly Dictionary<string, TValue> Properties;

        #endregion Fields

        #region Properties

        public int Count => ((IDictionary<string, TValue>)Properties).Count;
        public bool IsReadOnly => ((IDictionary<string, TValue>)Properties).IsReadOnly;
        public ICollection<string> Keys => ((IDictionary<string, TValue>)Properties).Keys;
        public ICollection<TValue> Values => ((IDictionary<string, TValue>)Properties).Values;

        #endregion Properties

        #region Constructors

        public PropertyContainer()
        {
            Properties = new Dictionary<string, TValue>();
        }

        #endregion Constructors

        #region Methods

        // Methods
        public void Add(string key, TValue value)
        { ((IDictionary<string, TValue>)Properties).Add(key, value); }

        public void Add(KeyValuePair<string, TValue> item)
        {
            ((IDictionary<string, TValue>)Properties).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<string, TValue>)Properties).Clear();
        }

        public bool Contains(KeyValuePair<string, TValue> item)
        {
            return ((IDictionary<string, TValue>)Properties).Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return ((IDictionary<string, TValue>)Properties).ContainsKey(key);
        }

        public void CopyFrom(PropertyContainer<TValue> original)
        {
            foreach (KeyValuePair<string, TValue> property in original.Properties)
            {
                Add(property.Key, property.Value);
            }
        }

        public void CopyTo(KeyValuePair<string, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<string, TValue>)Properties).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator()
        {
            return ((IDictionary<string, TValue>)Properties).GetEnumerator();
        }

        public T GetProperty<T>(string name)
        {
            if (ContainsKey(name))
            {
                return ConversionOperations.ConvertTo<T>(this[name]);
            }
            else
            {
                return default(T);
            }
        }

        public bool Remove(string key)
        {
            return ((IDictionary<string, TValue>)Properties).Remove(key);
        }

        public bool Remove(KeyValuePair<string, TValue> item)
        {
            return ((IDictionary<string, TValue>)Properties).Remove(item);
        }

        public void SetProperty(string name, TValue value)
        {
            if (ContainsKey(name)) { this[name] = value; }
            else { Add(name, value); }
        }

        public bool TryGetProperty<T>(string name, out T value)
        {
            if (Properties.ContainsKey(name))
            {
                value = ConversionOperations.ConvertTo<T>(this[name]);
                return true;
            }
            else
            {
                value = default(T);
                return false;
            }
        }

        public bool TryGetValue(string key, out TValue value)
        {
            return ((IDictionary<string, TValue>)Properties).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<string, TValue>)Properties).GetEnumerator();
        }

        #endregion Methods

        #region Indexers

        // Properties
        public TValue this[string key]
        {
            get { return ((IDictionary<string, TValue>)Properties)[key]; }
            set { ((IDictionary<string, TValue>)Properties)[key] = value; }
        }

        #endregion Indexers
    }
}
