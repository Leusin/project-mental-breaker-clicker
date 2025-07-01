// Slider Button UI 처리 클래스

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MBSliderButtonUI : MonoBehaviour
{
    public MBBreathController controller;

    public CanvasGroup canvasGroup;
    private TMP_Text _label;
    private Slider _slider;
    private Button _button;

    void Awake()
    {
        _label ??= gameObject.GetComponentInChildren<TMP_Text>();
        _slider ??= gameObject.GetComponentInChildren<Slider>();
        _button ??= gameObject.GetComponent<Button>();
    }

    void Start()
    {
        _button.onClick.AddListener(() => controller.TriggerButton());
        
        // TEMP
        controller.StartBreathCharging();
        _label.text = $"[ 심호흡 하기 ]";
    }

    void Update()
    {
        var data = controller.data;
        _slider.minValue = 0;
        _slider.maxValue = data.MaxPoint;
        _slider.value = data.currentPoint;

        // TEMP
        canvasGroup.alpha = data.currentPoint < data.MaxPoint ? 0.8f : 1.0f;
    }
}
