using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 업글 UI 생성 + Controller 생성  
/// </summary>
public class MBUpgradePanelController: MonoBehaviour
{
    public GameObject upgradeEntryPrefab;
    public Transform contentRoot;

    private MBUpgradeListSpawner _upgradeController;

    void Start()
    {
        // 컨트롤러 생성 시 필요한 것들 주입
        var stats = MBDataManager.Instance.MentalStats;
        var manager = MBUpgradeListManager.Instance;
        _upgradeController = new MBUpgradeListSpawner(manager, stats);

        LoadUpgrades();
    }

    public void LoadUpgradeList(List<MBUpgradeRuntimeData> upgrades)
    {
        foreach (var data in upgrades)
        {
            GameObject go = Instantiate(upgradeEntryPrefab, contentRoot);
            MBUpgradeUIEntry entry = go.GetComponent<MBUpgradeUIEntry>();
            entry.Setup(data, OnUpgradeClicked);
        }
    }
    private void LoadUpgrades()
    {
        List<MBUpgradeRuntimeData> allUpgrades = _upgradeController.GetAllUpgrades();
        LoadUpgradeList(allUpgrades);
    }

    private void OnUpgradeClicked(MBUpgradeRuntimeData clickedUpgrade)
    {
        Debug.Log($"업글 시도: {clickedUpgrade.data.upgradeName}");

        // MP 차감 / 업글 레벨 증가 등 처리 가능
    }
}
