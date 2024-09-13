using System.Threading.Tasks;

namespace Memory2.Scripts.Game.Global.Storages.Root {
    public interface ISave {
        string GetKey();
        void Save();
    }
}