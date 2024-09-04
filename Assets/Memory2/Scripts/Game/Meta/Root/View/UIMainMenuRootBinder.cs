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

        public void Bind(UnityAction startGameplay, UnityAction locationsAction) {
            _startGameplayButton.Subscribe(startGameplay);
            _locationsButton.Subscribe(locationsAction);
        }
    }
}