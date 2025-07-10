using UnityEngine;
using UnityEngine.EventSystems;

public class MBClickArea : MonoBehaviour
{

    private MBMentalStatData _mentalStatData;
    private MBBreatheData _breatheData;

    private void Start()
    {
        _mentalStatData = MBDataManager.Instance.MentalStats;
        _breatheData = MBDataManager.Instance.BreathData;
    }

    public void OnMouseDown()
    {
        if (EventSystem.current == null)
        {
            return;
        }

        // PC 마우스 입력인 경우
        if (Input.touchCount == 0 && EventSystem.current.IsPointerOverGameObject() && _breatheData.state == MBBreathState.Idle)
        {
            return;
        }

        // 모바일 터치 입력인 경우
        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && _breatheData.state == MBBreathState.Idle)
        {
            return;
        }

        _mentalStatData.MentalPoint += _breatheData.PerBreath;
    }
}
