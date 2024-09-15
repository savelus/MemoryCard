using System;
using Memory2.Scripts.Game.Global.Enums;

namespace Memory2.Scripts.Game.Global.Configs.Elements {
    [Serializable]
    public class ElementsDependencies {
        public Element Element;
        public Element[] Dependencies;
    }
}