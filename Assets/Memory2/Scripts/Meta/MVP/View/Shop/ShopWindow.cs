using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.VisibilityMechanisms;
using Memory2.Scripts.Meta.MVP.Interfaces;
using TMPro;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.View.Shop {
    public class ShopWindow : BaseWindow, IShopWindow {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private TextMeshProUGUI _money;

        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _shopCloseHint;

        protected override void OnEnable() {
            ChangeShowMechanism(new FadeShowMechanism(_group));
            ChangeHideMechanism(new FadeHideMechanism(_group));
        }

        public Transform GetElementParent() {
            return _content;
        }

        public void UpdateMoney(string value) {
            _money.text = value;
        }

        public void ShopIsClose(bool isClose) {
            _shopCloseHint.SetActive(isClose);
        }
    }
}