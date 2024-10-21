using Memory2.Scripts.Utils;
using R3;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Meta.Root.View {
    public class UIMainMenuRootBinder : MonoBehaviour {
        [SerializeField] private Button _startGameplayButton;
        [SerializeField] private Button _locationsButton;
        [SerializeField] private Button _cardCollectionButton;
        [SerializeField] private Button _shopButton;

        public void Bind(UnityAction startGameplay, UnityAction locationsAction, UnityAction cardCollectionAction, UnityAction shopAction) {
            _startGameplayButton.Subscribe(startGameplay);
            _locationsButton.Subscribe(locationsAction);
            _cardCollectionButton.Subscribe(cardCollectionAction);
            _shopButton.Subscribe(shopAction);
        }
    }
}