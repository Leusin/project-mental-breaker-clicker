using UnityEngine;
using UnityEngine.EventSystems;
using Leusin.Tools.Effects;

public class MBClickArea : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    private MBMentalStatData _mentalStat;
    private MBBreatheData _breathe;
    private MBEffectManager _effectManager;

    private void Start()
    {
        _mentalStat = MBDataManager.Instance.MentalStats;
        _breathe = MBDataManager.Instance.BreathData;
        _effectManager = MBEffectManager.Instance;
    }

    public void OnMouseDown()
    {
        if (EventSystem.current == null)
        {
            return;
        }

        // PC 마우스 입력인 경우
        if (Input.touchCount == 0 && EventSystem.current.IsPointerOverGameObject() && _breathe.state == MBBreathState.Idle)
        {
            return;
        }

        // 모바일 터치 입력인 경우
        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && _breathe.state == MBBreathState.Idle)
        {
            return;
        }

        long gained = _breathe.PerBreath;
        _mentalStat.MentalPoint += gained;
        _effectManager.PlayFloatingText(gained.ToString());
    }
}
