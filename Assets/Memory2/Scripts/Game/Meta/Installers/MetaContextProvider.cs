using System;
using Memory2.Scripts.Game.Global.MVP.Context;
using Memory2.Scripts.Game.Global.MVP.Context.Base;
using Memory2.Scripts.Game.Global.MVP.Enums;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Installers {
    public sealed class MetaContextProvider : IContext,
                                       IInitializable,
                                       IDisposable {
        private readonly IContextService _contextService;
        private readonly DiContainer _container;

        public MetaContextProvider(IContextService contextService, DiContainer container) {
            _contextService = contextService;
            _container = container;
        }

        public void Initialize() {
            RegisterContext();
        }

        public GameContext Context()
            => GameContext.Meta;

        public void RegisterContext() {
            _contextService.Register(Context(), _container);
        }

        public void UnRegisterContext() {
            _contextService.UnRegister(Context());
        }

        public void Dispose() {
            UnRegisterContext();
        }
    }
}