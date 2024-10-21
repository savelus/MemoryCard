using Memory2.Scripts.Core.MVP.Base;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.Interfaces {
    public interface IShopWindow : IWindowView {
        Transform GetElementParent();
        void UpdateMoney(string value);
        void ShopIsClose(bool isClose);
    }
}