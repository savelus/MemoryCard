﻿using System;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class CustomShowMechanism : IShowMechanism {
        private readonly Action _customShow;

        public CustomShowMechanism(Action customShow) {
            _customShow = customShow;
        }

        public void Show(GameObject controlObject, Action onShow = null) {
            _customShow.Invoke();
        }

        public void ShowImmediate(GameObject controlObject) {
            _customShow.Invoke();
        }
    }
}