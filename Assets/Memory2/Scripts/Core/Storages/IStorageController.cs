namespace Memory2.Scripts.Core.Storages {
    public interface IStorageController {
        bool SaveAll();
        bool Save(string key);
    }
}