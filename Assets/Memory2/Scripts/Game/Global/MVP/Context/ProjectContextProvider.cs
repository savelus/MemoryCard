using System;
using Memory2.Scripts.Game.Global.MVP.Context.Base;
using Memory2.Scripts.Game.Global.MVP.Enums;
using Zenject;

namespace Memory2.Scripts.Game.Global.MVP.Context {
    public class ProjectContextProvider : IContext,
                                          IInitializable,
                                          IDisposable {
        private readonly IContextService _contextService;
        private readonly DiContainer _container;

        public ProjectContextProvider(IContextService contextService,
                                      DiContainer container) {
            _contextService = contextService;
            _container = container;
        }

        public void Initialize() {
            RegisterContext();
        }

        public GameContext Context()
            => GameContext.Project;

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