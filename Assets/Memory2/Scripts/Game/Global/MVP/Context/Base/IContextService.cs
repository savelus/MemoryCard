using System;
using Memory2.Scripts.Game.Global.MVP.Enums;
using Zenject;

namespace Memory2.Scripts.Game.Global.MVP.Context.Base {
    public interface IContextService {
        void SubscribeOnRegister(Action<GameContext> onRegister);
        void SubscribeOnRegister(Action<GameContext> onRegister, GameContext gameContext);
        void SubscribeOnRegister(Action<DiContainer> onRegister, GameContext gameContext);
        void UnsubscribeOnRegister(Action<DiContainer> onRegister);
        void UnsubscribeOnRegister(Action<GameContext> onRegister);
        Action<GameContext> OnContextUnRegister { get; set; }
        bool IsContextAvailable(GameContext context);
        DiContainer ResolveContainer(GameContext context);
        void Register(GameContext context, DiContainer diContainer);
        void UnRegister(GameContext context);
    }
}