using UnityEngine;

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
        _mentalStatData.MentalPoint += _breatheData.PerBreath;
    }
}
