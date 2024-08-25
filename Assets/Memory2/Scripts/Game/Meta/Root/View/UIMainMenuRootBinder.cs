using Memory2.Scripts.Game.Extensions;
using R3;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Meta.Root.View {
    public class UIMainMenuRootBinder : MonoBehaviour {
        [SerializeField] private Button _startGameplayButton;

        public void Bind(UnityAction startGameplay) {
            _startGameplayButton.Subscribe(startGameplay);
        }
    }
}