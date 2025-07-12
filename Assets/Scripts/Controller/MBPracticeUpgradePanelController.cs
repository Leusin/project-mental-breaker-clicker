using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 업글 UI 생성 + Controller 생성  
/// PracticeUpgrade 의 공통된 로직 설정
/// </summary>
public class MBPracticeUpgradePanelController : MonoBehaviour
{
    public GameObject upgradeEntryPrefab;
    public Transform contentRoot;

    private MBBreatheData _breathe;
    private MBMentalStatData _mentalStats;
    private MBUpgradeLists _upgrades;

    private void Awake()
    {
        if (upgradeEntryPrefab == null || contentRoot == null)
        {
            Debug.LogError("업글 UI 프리팹이나 컨텐츠 루트가 설정되지 않았습니다.");
            return;
        }
    }

    private void Start()
    {
        // 컨트롤러 생성 시 필요한 것들 주입
        _breathe = MBDataManager.Instance.BreathData;
        _mentalStats = MBDataManager.Instance.MentalStats;
        _upgrades = MBDataManager.Instance.UpgradeList;
        LoadUpgradeList(_upgrades.PracticeUpgradeList);
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

    private void OnUpgradeClicked(MBUpgradeRuntimeData clickedUpgrade)
    {
        Debug.Log($"업글 시도: {clickedUpgrade.data.upgradeName}");

        if (clickedUpgrade.CurrentCost > _mentalStats.MentalPoint)
        {
            Debug.LogWarning("정신력이 부족합니다.");
            return;
        }

        _mentalStats.MentalPoint -= clickedUpgrade.CurrentCost;
        clickedUpgrade.Level++;

        UpdateBreathBonus();
    }

    private void UpdateBreathBonus()
    {
        _breathe.PerBreath = _upgrades.GetClickBonus();
    }
}
