using Leusin.Tools;
using UnityEngine;

public class MBDataManager : MonoBehaviourSingleton<MBDataManager>
{
    public MBBreatheData BreathData { get; private set; }
    public MBMentalStatData MentalStats { get; private set; }
    public MBUpgradeList UpgradeList { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        BreathData = new MBBreatheData();
        MentalStats = new MBMentalStatData();
        UpgradeList = new MBUpgradeList();
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
