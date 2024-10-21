namespace Memory2.Scripts.Core.Storages {
    public interface ISave {
        string GetKey();
        void Save();
    }
}