using Leusin.Tools;
using UnityEngine;

public class MBDataManager : MonoBehaviourSingleton<MBDataManager>
{
    public MBBreatheData BreathData { get; private set; }
    public MBMentalStatData MentalStats { get; private set; }
    public MBUpgradeLists UpgradeList { get; private set; }
    public MBGameDayTracker GameDayController { get; private set; }
    public MBRandomEventLists RandomEventLists { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        BreathData = new MBBreatheData();
        MentalStats = new MBMentalStatData();
        UpgradeList = new MBUpgradeLists();
        GameDayController = new MBGameDayTracker();
        RandomEventLists = new MBRandomEventLists();
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
