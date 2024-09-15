using System;
using System.Collections.Generic;

namespace Memory2.Scripts.Utils {
    public static class DictionaryExtensions {
        public static bool IsNullOrEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            return dictionary == null || dictionary.Count == 0;
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TValue : new() {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            
            if(dictionary.TryGetValue(key, out var value)) return value;

            value = new TValue();
            dictionary[key] = value;
            return value;
        }
    }
}