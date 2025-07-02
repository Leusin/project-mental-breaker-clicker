using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MBBreatheUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public MBBreatheController controller;

    private MBBreatheData _data;
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
        _data = MBDataManager.Instance.BreathData;
        
        controller = new MBBreatheController(_data, MBDataManager.Instance.MentalStats);
        controller.StartBreathCharging();

        _button.onClick.AddListener(() => controller.TriggerButton());

        //_label.text = $"[ 심호흡 하기 ]";
    }

    void Update()
    {
        _slider.minValue = 0;
        _slider.maxValue = _data.MaxPoint;
        _slider.value = _data.currentPoint;

        canvasGroup.alpha = _data.currentPoint < _data.MaxPoint ? 0.8f : 1.0f;
    }
}
