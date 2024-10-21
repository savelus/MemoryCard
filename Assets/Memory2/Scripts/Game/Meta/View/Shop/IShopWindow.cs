using Memory2.Scripts.Game.Global.MVP.WindowService;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.View.Shop {
    public interface IShopWindow : IWindowView {
        Transform GetElementParent();
        void UpdateMoney(string value);
        void ShopIsClose(bool isClose);
    }
}