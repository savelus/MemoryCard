using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Game.Global.Configs;
using Memory2.Scripts.Game.Global.MVP.AssetManager;
using Memory2.Scripts.Game.Global.MVP.Base;
using Memory2.Scripts.Game.Global.MVP.Context.Base;
using Memory2.Scripts.Game.Global.MVP.Enums;
using Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.MVP.WindowService {
    public class WindowFactory {
        private readonly IContextService _contextService;
        private readonly IAssetService _service;


        [Inject]
        protected WindowFactory(IContextService contextService,
                                IAssetService assets) {
            _contextService = contextService;
            _service = assets;
        }
        public async UniTask<UIWindow> Create(WindowConfig data, Transform parent, WindowKey key,
            Vector3 position) {
            var uid = Guid.NewGuid().ToString();

            IBasePresenter<WindowKey> controller = CreateController(data);
            BaseView view = await CreateView(data);

            var window = new UIWindow(uid, data, key, controller, view);
            window.SetPlace(parent, position);

            view.gameObject.SetActive(true);
            
            return window;
        }

        private IBasePresenter<WindowKey> CreateController(WindowConfig data) {
            var controller = Activator.CreateInstance(data.Controller, _contextService);

            var container = _contextService.ResolveContainer(data.Context);
            container.Inject(controller);

            return controller as IBasePresenter<WindowKey>;
        }

        private async UniTask<BaseView> CreateView(WindowConfig data) {
            var prefab = await _service.Load<GameObject>(data.PrefabReference);

            var container = _contextService.ResolveContainer(data.Context);

            var view = container.InstantiatePrefabForComponent<BaseView>(prefab);
            return view;
        }
    }
}
