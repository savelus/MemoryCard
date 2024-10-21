using Memory2.Scripts.Core.MVP.Base;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.Interfaces {
    public interface ICardCollectionWindow : IWindowView {
        void Init(int maxCountCard);
        void AddCollectionElement(Transform element);
        void SetSelectedCard(int currentCard);
    }
}