﻿using Memory2.Scripts.Meta.MVP.View;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Meta.Configs.Installers {
    [CreateAssetMenu(fileName = "MetaViewsConfig", menuName = "Configs/MetaViews")]
    public class LocationViewsInstaller : ScriptableObjectInstaller<LocationViewsInstaller> {
        [SerializeField] private LocationMapView _locationMapView;
        [SerializeField] private LocationView _locationView;

        public override void InstallBindings() { }
    }
}