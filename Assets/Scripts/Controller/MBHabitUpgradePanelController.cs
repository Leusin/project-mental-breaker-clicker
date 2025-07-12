using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 업글 UI 생성 + Controller 생성  
/// HabitUpgrade 의 공통된 로직 설정
/// </summary>
public class MBHabitUpgradePanelController : MonoBehaviour
{
    public GameObject upgradeEntryPrefab;
    public Transform contentRoot;

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

        // 업그레이드 구매
        _mentalStats.MentalPoint -= clickedUpgrade.CurrentCost;

        // 업그레이드 레벨 증가
        clickedUpgrade.Level++;

        // 업그레이드 효과 업데이트
        _mentalStats.PerSec = (long)_upgradeManager.GetTotalMPPerSec();

        // Mood 업데이트
        _mentalStats.Mood += _moodChange;
    }

    private float _moodChange = 0.01f;
    private MBMentalStatData _mentalStats;
    private MBUpgradeList _upgradeManager;

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
        _mentalStats = MBDataManager.Instance.MentalStats;
        _upgradeManager = MBDataManager.Instance.UpgradeList;
        LoadUpgradeList(_upgradeManager.HabitUpgradeList);

        // 오프라인동안
        _mentalStats.MentalPoint += (long)(_upgradeManager.GetTotalMPPerSec() * TimeAfterLastPlay);
        // 1초마다 자동으로 포인트 적립
        InvokeRepeating(nameof(GainPassiveMP), 1f, 1f);
    }

    private DateTime GetLastPlayerDate()
    {
        if (!PlayerPrefs.HasKey(CGPlayerPrefKeys.GetTimeKey()))
        {
            return DateTime.Now;
        }

        string timeBinaryInString = PlayerPrefs.GetString(CGPlayerPrefKeys.GetTimeKey());
        long timeBinaryInLong = Convert.ToInt64(timeBinaryInString);

        return DateTime.FromBinary(timeBinaryInLong);
    }

    // Time After Last Play Section

    private void GainPassiveMP()
    {
        var passiveGain = _mentalStats.PerSec;
        _mentalStats.MentalPoint += (long)passiveGain;
    }

    public float TimeAfterLastPlay
    {
        get
        {
            DateTime currentTime = DateTime.Now;
            DateTime lastPlayDate = GetLastPlayerDate();

            return (float)currentTime.Subtract(lastPlayDate).TotalSeconds;
        }
    }

    private void UpdateLastPlayerDate()
    {
        PlayerPrefs.SetString(CGPlayerPrefKeys.GetTimeKey(), DateTime.Now.ToBinary().ToString());
    }

    private void OnApplicationQuit()
    {
        UpdateLastPlayerDate();
    }
}
