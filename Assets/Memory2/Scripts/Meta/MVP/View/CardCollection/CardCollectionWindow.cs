using DG.Tweening;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.VisibilityMechanisms;
using Memory2.Scripts.Meta.MVP.Interfaces;
using TMPro;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UI;

namespace Memory2.Scripts.Meta.MVP.View.CardCollection {
    public class CardCollectionWindow : BaseWindow, ICardCollectionWindow {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private TextMeshProUGUI _selectedCard;
        [SerializeField] private Transform _content;

        private int _maxCountCard;

        private readonly Color _targetColorException = Color.red;
        private readonly Color _originColor = Color.white;
        
        private const string DEFAULT_SELECTED_CARD_STRING = "Выбрано карт: {0} / {1}";

        private Sequence _warningSequence;
        
        protected override void OnEnable() {
            ChangeShowMechanism(new FadeShowMechanism(_group));
            ChangeHideMechanism(new FadeHideMechanism(_group));
        }

        public void Init(int maxCountCard) {
            _maxCountCard = maxCountCard;

            CreateSequences();
        }

        public void AddCollectionElement(Transform element) {
            element.SetParent(_content, false);
        }

        public void SetSelectedCard(int currentCard) {
            _selectedCard.text = string.Format(DEFAULT_SELECTED_CARD_STRING, currentCard, _maxCountCard);
        }

        public void ShowWarningFullCard() {
            _selectedCard.color = _targetColorException;
            _warningSequence.Restart();
        }

        private void CreateSequences() {
            _warningSequence ??= DOTween.Sequence()
                .Append(_selectedCard.transform.DOScale(1.3f, 0.5f))
                .Append(_selectedCard.transform.DOScale(1f, 0.3f))
                .AppendCallback(() => _selectedCard.color = _originColor)
                .SetAutoKill(false)
                .Pause();
        }

        public override void Dispose() {
            _warningSequence.Kill();
        }
    }
}