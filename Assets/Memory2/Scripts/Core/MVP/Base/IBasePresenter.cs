using Cysharp.Threading.Tasks;

namespace Memory2.Scripts.Core.MVP.Base {
    public interface IBasePresenter<TKey> where TKey : System.Enum {
        UniTask Initialize(IWindowData data, TKey key, bool isInit = false);
        UniTask Open();
        UniTask Close();
        void PreloadInitialize();
        void InitDependencies();
        void InitializeView(IView view);
        UniTask Dispose();
        UniTask InitializeOnce();
    }
}