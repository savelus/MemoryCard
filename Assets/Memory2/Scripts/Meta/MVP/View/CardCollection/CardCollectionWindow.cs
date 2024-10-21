using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.VisibilityMechanisms;
using Memory2.Scripts.Meta.MVP.Interfaces;
using TMPro;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.View.CardCollection {
    public class CardCollectionWindow : BaseWindow, ICardCollectionWindow {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private TextMeshProUGUI _selectedCard;
        [SerializeField] private Transform _content;

        private const string DefaultSelectedCardString = "Выбрано карт: {0} / {1}";
        private int _maxCountCard;

        protected override void OnEnable() {
            ChangeShowMechanism(new FadeShowMechanism(_group));
            ChangeHideMechanism(new FadeHideMechanism(_group));
        }

        public void Init(int maxCountCard) {
            _maxCountCard = maxCountCard;
        }

        public void AddCollectionElement(Transform element) {
            element.SetParent(_content, false);
        }

        public void SetSelectedCard(int currentCard) {
            _selectedCard.text = string.Format(DefaultSelectedCardString, currentCard, _maxCountCard);
        }
    }
}