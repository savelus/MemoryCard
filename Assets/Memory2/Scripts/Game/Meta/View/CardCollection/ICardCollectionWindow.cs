using Memory2.Scripts.Game.Global.MVP.WindowService;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Meta.View.CardCollection {
    public interface ICardCollectionWindow : IWindowView {
        void Init(int maxCountCard);
        void AddCollectionElement(Transform element);
        void SetSelectedCard(int currentCard);
    }
}