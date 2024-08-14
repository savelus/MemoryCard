using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Core.Storages;
using Memory2.Scripts.Game.Core.View;
using Zenject;

namespace Memory2.Scripts.Game.Core.Presenters {
    public sealed class PointsPresenter : IInitializable {
        private readonly PointStorage _pointStorage;
        private readonly PointsView _pointsView;
        private readonly UIGameplayRoot _uiGameplayRoot;

        public PointsPresenter(PointStorage pointStorage, PointsView pointsView, UIGameplayRoot uiGameplayRoot) {
            _pointStorage = pointStorage;
            _pointsView = pointsView;
            _uiGameplayRoot = uiGameplayRoot;
        }
        
        public void Initialize() {
            SetupView();
            _pointStorage.PointsChanged += UpdatePoints;
            
            UpdatePoints(_pointStorage.GetPoints());
        }

        private void SetupView() {
            _pointsView.transform.SetParent(_uiGameplayRoot.transform, false);
        }

        private void UpdatePoints(int points) {
            _pointsView.SetPoints(points.ToString());
        }
    }
}