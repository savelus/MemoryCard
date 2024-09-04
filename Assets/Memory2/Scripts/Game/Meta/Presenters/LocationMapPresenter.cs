using System.Collections.Generic;
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
        private List<LocationButton> _buttons;

        public LocationMapPresenter(LocationMapView mapView,
                                    LocationsConfig locationsConfig,
                                    LocationPresenter locationPresenter) {
            _mapView = mapView;
            _locationsConfig = locationsConfig;
            _locationPresenter = locationPresenter;
        }

        void IInitializable.Initialize() {
            _buttons = new List<LocationButton>();
        }

        public void Open() {
            ClearLastButtons();
            foreach (var (locationDataId, locationDataValue) in _locationsConfig.GetLocationsMap()) {
                var button = CreateButton();
                _buttons.Add(button);
                button.Initialize(locationDataValue.ButtonSprite, () => OnLocationClicked(locationDataId));
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