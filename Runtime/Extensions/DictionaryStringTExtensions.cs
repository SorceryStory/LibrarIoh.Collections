using SorceressSpell.LibrarIoh.Core;
using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Collections
{
    public static class DictionaryStringTExtensions
    {
        #region Methods

        public static T GetValue<T>(this IDictionary<string, T> dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
            {
                return ConversionOperations.ConvertTo<T>(dictionary[key]);
            }
            else
            {
                return default(T);
            }
        }

        public static void SetPair<T>(this IDictionary<string, T> dictionary, string key, T value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public static bool TryGetValue<T>(this IDictionary<string, T> dictionary, string key, out T value)
        {
            if (dictionary.ContainsKey(key))
            {
                value = ConversionOperations.ConvertTo<T>(dictionary[key]);
                return true;
            }
            else
            {
                value = default(T);
                return false;
            }
        }

        public static void CopyFrom<T>(this IDictionary<string, T> dictionary, IDictionary<string, T> original)
        {
            foreach (KeyValuePair<string, T> property in original)
            {
                dictionary.Add(property.Key, property.Value);
            }
        }
    }

    #endregion Methods
}
