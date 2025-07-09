using System.Collections.Generic;

/// <summary>
/// 클릭 처리 로직 처리 (MP 소모, 레벨업 등)
/// </summary>
public class MBUpgradeListSpawner 
{
    private MBUpgradeListManager _upgradeManager;
    private MBMentalStatData _statsData;

    public MBUpgradeListSpawner(MBUpgradeListManager manager, MBMentalStatData stats)
    {
        _upgradeManager = manager;
        _statsData = stats;
    }

    public List<MBUpgradeRuntimeData> GetAllUpgrades()
    {
        return _upgradeManager.upgradeList;
    }

    public bool TryPurchaseUpgrade(MBUpgradeRuntimeData upgrade)
    {
        long cost = upgrade.CurrentCost;
        if (_statsData.MentalPoint >= cost)
        {
            _statsData.MentalPoint -= cost;
            upgrade.Level++;
            return true;
        }
        return false;
    }
}
