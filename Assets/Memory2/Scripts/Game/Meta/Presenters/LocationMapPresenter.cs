using System.Collections.Generic;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Meta.Configs;
using Memory2.Scripts.Game.Meta.Data;
using Memory2.Scripts.Game.Meta.View;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Presenters {
    public sealed class LocationMapPresenter : IInitializable {
        private readonly LocationMapView _mapView;
        private readonly LocationsConfig _locationsConfig;
        private readonly LocationPresenter _locationPresenter;
        private readonly ProgressStorage _progressStorage;
        
        private List<LocationButton> _buttons;

        public LocationMapPresenter(LocationMapView mapView,
                                    LocationsConfig locationsConfig,
                                    LocationPresenter locationPresenter,
                                    ProgressStorage progressStorage) {
            _mapView = mapView;
            _locationsConfig = locationsConfig;
            _locationPresenter = locationPresenter;
            _progressStorage = progressStorage;
        }

        void IInitializable.Initialize() {
            _buttons = new List<LocationButton>();
        }

        public void Open() {
            var currentLocation = _progressStorage.CurrentLocation;
            ClearLastButtons();
            foreach (var (locationDataId, locationDataValue) in _locationsConfig.GetLocationsMap()) {
                var button = CreateButton();
                _buttons.Add(button);
                if (locationDataId <= currentLocation) {
                    button.Initialize(locationDataValue.ButtonSprite, true, () => OnLocationClicked(locationDataId));
                }
                else {
                    button.Initialize(locationDataValue.ButtonSprite, false, null);
                }
                
            }

            _mapView.Open();
            _mapView.SubscribeOnCloseButton(OnCloseButtonClicked);
        }

        private void ClearLastButtons() {
            foreach (var locationButton in _buttons) {
                Object.Destroy(locationButton.gameObject);
            }
            _buttons.Clear();
        }

        private void OnCloseButtonClicked() {
            _mapView.Close();
        }

        private void OnLocationClicked(int locationDataId) {
            _locationPresenter.Open(locationDataId);
        }

        private LocationButton CreateButton() {
            var button = Object.Instantiate(_locationsConfig.LocationsButtonPrefab);
            _mapView.AddLocationButton(button.transform);
            return button;
        }
    }
}