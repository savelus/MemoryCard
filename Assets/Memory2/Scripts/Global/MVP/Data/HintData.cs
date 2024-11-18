using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Global.MVP.Enums;
using UnityEngine;

namespace Memory2.Scripts.Global.MVP.Data {
    public class HintData : IWindowData {
        public string HintText;
        public HintPosition PositionType;
        public Vector2 Position;
    }
}