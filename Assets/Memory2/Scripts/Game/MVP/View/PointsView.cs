using TMPro;
using UnityEngine;

namespace Memory2.Scripts.Game.MVP.View {
    public class PointsView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _currentPoints;

        public void SetPoints(string points) {
            _currentPoints.text = points;
        }
    }
}