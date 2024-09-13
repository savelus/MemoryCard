using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memory2.Scripts.Game.Global.Storages.Root {
    public class StorageController : IStorageController {
        private readonly Dictionary<string, ISave> _storages = new();

        private readonly List<Task> _tasks = new();

        public StorageController(List<ISave> storages) {
            _storages.Clear();
            foreach (var storage in storages) {
                _storages.Add(storage.GetKey(), storage);
            }
        }
        public bool SaveAll() {
            foreach (var storage in _storages.Values) {
                storage.Save();
            }

            return true;
        }

        public bool Save(string key) {
            if (!_storages.TryGetValue(key, out var storage)) return false;
            storage.Save();
            
            return true;
        }
    }
}