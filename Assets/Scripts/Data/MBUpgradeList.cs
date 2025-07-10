using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 업글 데이터 리스트 보유
/// MBUpgradeData를 로드 한 뒤 MBUpgradeRuntimeData로 변환하여 리스트에 저장
/// 전체 업그레이드 데이터에 대한 접근을 제공
/// </summary>
public class MBUpgradeList
{
    public List<MBUpgradeRuntimeData> upgradeList;

    public MBUpgradeList()
    {
        LoadUpgradeData();
    }

    private void LoadUpgradeData()
    {
        MBUpgradeData[] upgrades = Resources.LoadAll<MBUpgradeData>("Upgrade");
        upgradeList = new List<MBUpgradeRuntimeData>();

        foreach (var upgrade in upgrades)
        {
            upgradeList.Add(new MBUpgradeRuntimeData(upgrade));
        }

        Debug.Log($"[MBUpgradeListManager] {upgradeList.Count}개의 업그레이드 불러옴.");
    }

    public float GetTotalMPPerSec()
    {
        return upgradeList
            .Where(u => u.data is MBPassiveUpgradeData)
            .Sum(u => u.CurrentEffect);
    }

    public float GetClickBonus()
    {
        return upgradeList
            .Where(u => u.data is MBPracticeUpgradeData)
            .Sum(u => u.CurrentEffect);
    }
}
