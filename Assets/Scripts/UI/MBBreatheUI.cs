using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MBBreatheUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TMP_Text label;
    public TMP_Text multiplierValue;

    private MBBreatheController _controller;
    private MBBreatheData _data;
    private Slider _slider;
    private Button _button;

    void Awake()
    {
        _slider ??= gameObject.GetComponentInChildren<Slider>();
        _button ??= gameObject.GetComponent<Button>();
    }

    void Start()
    {
        _data = MBDataManager.Instance.BreathData;

        _controller = new MBBreatheController(_data, MBDataManager.Instance.MentalStats, MBEffectManager.Instance, MBDataManager.Instance.GameDayTracker);
        _controller.StartBreathCharging();

        _button.onClick.AddListener(() => _controller.TriggerBreathe());

        //_label.text = $"[ 심호흡 하기 ]";
    }

    void Update()
    {
        _slider.minValue = 0;
        _slider.maxValue = _data.MaxPoint;
        _slider.value = _data.currentSliderVal;

        multiplierValue.text = _data.Multiplier.ToString();

        canvasGroup.alpha = _data.currentSliderVal < _data.MaxPoint ? 0.8f : 1.0f;
    }
}
