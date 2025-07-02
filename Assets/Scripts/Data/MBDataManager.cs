using Leusin.Tools;
using UnityEngine;

public class MBDataManager : MonoBehaviourSingleton<MBDataManager>
{
    public MBBreatheData BreathData { get; private set; }
    public MBMentalStatData MentalStats { get; private set; }

    // TODO: UpgradeData 클래스 추가 

    protected override void Awake()
    {
        base.Awake();

        BreathData = new MBBreatheData();
        MentalStats = new MBMentalStatData();
    }
    
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
