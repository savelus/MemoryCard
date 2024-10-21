using System;
using Memory2.Scripts.Global.Enums;

namespace Memory2.Scripts.Global.Configs.Elements {
    [Serializable]
    public class ElementsDependencies {
        public Element Element;
        public Element[] Dependencies;
    }
}