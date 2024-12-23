﻿using System.ComponentModel;
using Memory2.Scripts.Meta.MVP.View.CardCollection;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Meta.Configs.Installers {
    [CreateAssetMenu(fileName = "CardCollectionConfig", menuName = "Configs/CardCollectionConfig")]
    public class CardCollectionConfigInstaller : ScriptableObjectInstaller<CardCollectionConfigInstaller> {
        [SerializeField] private CardCollectionConfig _cardCollectionConfig;

        [SerializeField] private CardCollectionWindow _cardCollectionWindow;

        public override void InstallBindings() {
            InstallConfigs();
        }

        private void InstallConfigs() {
            Container
                .BindInterfacesAndSelfTo<CardCollectionConfig>()
                .FromInstance(_cardCollectionConfig)
                .AsSingle();
        }
    }
}