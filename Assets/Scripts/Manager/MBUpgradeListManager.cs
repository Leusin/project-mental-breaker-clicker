using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Leusin.Tools;

/// <summary>
/// 업글 데이터 리스트 보유
/// </summary>
public class MBUpgradeListManager : MonoBehaviourSingleton<MBUpgradeListManager>
{
    public List<MBUpgradeRuntimeData> upgradeList;

    protected override void Awake()
    {
        base.Awake();
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

    public int GetClickBonus()
    {
        return (int)upgradeList
            .Where(u => u.data is MBActiveUpgradeData)
            .Sum(u => u.CurrentEffect);
    }
}
