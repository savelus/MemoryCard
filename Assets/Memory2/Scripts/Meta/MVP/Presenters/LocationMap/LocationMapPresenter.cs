using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.Enums;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.Signals;
using Memory2.Scripts.Global;
using Memory2.Scripts.Global.Configs;
using Memory2.Scripts.Global.MVP.Context;
using Memory2.Scripts.Global.MVP.Enums;
using Memory2.Scripts.Global.MVP.Views;
using Memory2.Scripts.Global.Storages;
using Memory2.Scripts.Meta.Configs;
using Memory2.Scripts.Meta.Data;
using Memory2.Scripts.Meta.MVP.Data;
using Memory2.Scripts.Meta.MVP.Interfaces;
using Memory2.Scripts.Meta.MVP.View;
using Memory2.Scripts.Meta.Storages;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Meta.MVP.Presenters.LocationMap {
    public sealed class LocationMapPresenter : BaseWindowPresenter<ILocationMapView, LocationMapData> {
        private LocationsConfig _locationsConfig;
        private ProgressStorage _progressStorage;
        private SignalBus _signalBus;

        private List<LocationButton> _buttons;

        public LocationMapPresenter(ContextService service) : base(service) { }

        [Inject]
        public void Inject(LocationsConfig locationsConfig,
            ProgressStorage progressStorage,
            SignalBus signalBus) {
            _signalBus = signalBus;
            _locationsConfig = locationsConfig;
            _progressStorage = progressStorage;
        }

        protected override async UniTask LoadContent() {
            _buttons = new();
            var currentLocation = _progressStorage.CurrentLocation;
            foreach (var (locationDataId, locationDataValue) in _locationsConfig.GetLocationsMap()) {
                var button = CreateButton();
                _buttons.Add(button);
                var sprite = _locationsConfig.GetLocationButtonVisual(locationDataValue.ButtonVisualId);
                if (locationDataId <= currentLocation) {
                    button.Initialize(sprite, true, () => OnLocationClicked(locationDataId));
                }
                else {
                    button.Initialize(sprite, false, null);
                }
            }

            View.OnClickCloseButton += OnCloseButtonClicked;
        }

        private void ClearLastButtons() {
            foreach (var locationButton in _buttons) {
                Object.Destroy(locationButton.gameObject);
            }

            _buttons.Clear();
        }

        private void OnCloseButtonClicked() {
            ClearLastButtons();
        }

        private void OnLocationClicked(int locationDataId) {
            _signalBus.Fire(new OpenWindowSignal(WindowKey.Location,
                new LocationWindowData() { LocationDataId = locationDataId }));
        }

        private LocationButton CreateButton() {
            var button = Object.Instantiate(_locationsConfig.LocationsButtonPrefab);
            View.AddLocationButton(button.transform);
            return button;
        }
    }
}