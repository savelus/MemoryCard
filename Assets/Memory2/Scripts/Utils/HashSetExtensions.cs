using System.Collections.Generic;

namespace Memory2.Scripts.Utils {
    public static class HashSetExtensions {
        public static int AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> list) {
            int indexer = 0;
            foreach (var value in list) {
                if (hashSet.Add(value)) {
                    indexer++;
                }
            }

            return indexer;
        }
    }
}