using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Global.Data;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.Configs {
    [Serializable]
    public class ElementsHierarchy {
        [SerializeField] private List<ElementsDependencies> Dependencies;
        
        
    }

    [Serializable]
    public class ElementsDependencies {
        public Element Element;
        public Element[] Dependencies;
    }
}