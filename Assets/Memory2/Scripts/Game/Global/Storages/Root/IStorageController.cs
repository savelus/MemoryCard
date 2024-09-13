using System.Threading.Tasks;

namespace Memory2.Scripts.Game.Global.Storages.Root {
    public interface IStorageController {
        bool SaveAll();
        bool Save(string key);
    }
} 