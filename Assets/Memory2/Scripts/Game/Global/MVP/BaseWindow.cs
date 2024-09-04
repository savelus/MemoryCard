using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Global.MVP {
    public class BaseWindow : MonoBehaviour {
        [SerializeField] protected Button _closeButton;
        
        public event UnityAction IsWindowOpened;
        public event UnityAction IsWindowClosed;

        public virtual void Load(){}

        public void Open() {
            gameObject.SetActive(true);
            IsWindowOpened?.Invoke();
        }

        public void Close() {
            gameObject.SetActive(false);
            IsWindowClosed?.Invoke();
        }
    }
}