using Memory2.Scripts.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Meta.MVP.View {
    public class UIMainMenuRootBinder : MonoBehaviour {
        [SerializeField] private Button _startGameplayButton;
        [SerializeField] private Button _locationsButton;
        [SerializeField] private Button _cardCollectionButton;
        [SerializeField] private Button _shopButton;

        public void Bind(UnityAction startGameplay, UnityAction locationsAction, UnityAction cardCollectionAction,
            UnityAction shopAction) {
            _startGameplayButton.Subscribe(startGameplay);
            _locationsButton.Subscribe(locationsAction);
            _cardCollectionButton.Subscribe(cardCollectionAction);
            _shopButton.Subscribe(shopAction);
        }
    }
}