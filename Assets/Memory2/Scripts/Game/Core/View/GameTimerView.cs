using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameTimerView : MonoBehaviour {
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private TextMeshProUGUI _timerText;
    
    public void SetTimer(string time, float currentTimePercent) {
        _timerSlider.value = currentTimePercent;
        _timerText.text = time;
    }
}