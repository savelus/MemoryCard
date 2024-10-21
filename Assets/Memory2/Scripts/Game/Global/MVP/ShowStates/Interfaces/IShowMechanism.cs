using System;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces {
    public interface IShowMechanism {
        void Show(GameObject controlObject, Action onShow = null);
        void ShowImmediate(GameObject controlObject);
    }
}