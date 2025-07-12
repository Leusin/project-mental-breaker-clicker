using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 업글 데이터 리스트 보유
/// MBUpgradeData를 로드 한 뒤 MBUpgradeRuntimeData로 변환하여 리스트에 저장
/// 전체 업그레이드 데이터에 대한 접근을 제공
/// </summary>
public class MBUpgradeLists
{
    public List<MBUpgradeRuntimeData> UpgradeList => _habitUpgradeList.Concat(_practiceUpgradeList).ToList();
    public List<MBUpgradeRuntimeData> HabitUpgradeList => _habitUpgradeList;
    public List<MBUpgradeRuntimeData> PracticeUpgradeList => _practiceUpgradeList;


    public long GetTotalMPPerSec()
    {
        return (long)_habitUpgradeList
            .Where(u => u.data is MBHabitUpgradeData && u.IsPurchased)
            .Sum(u => u.CurrentEffect);
    }

    public long GetClickBonus()
    {
        return (long)_practiceUpgradeList
            .Where(u => u.data is MBPracticeUpgradeData && u.IsPurchased)
            .Sum(u => u.CurrentEffect);
    }

    public MBUpgradeLists()
    {
        LoadUpgradeDataFromSO();
        LoadUpgradeDataFromJson();
    }

    private List<MBUpgradeRuntimeData> _practiceUpgradeList = new List<MBUpgradeRuntimeData>();
    private List<MBUpgradeRuntimeData> _habitUpgradeList = new List<MBUpgradeRuntimeData>();

    private void LoadUpgradeDataFromJson()
    {
        List<MBUpgradeConfigData> habitDTOs = MBJsonLoader.LoadUpgradeHabbit();
        List<MBUpgradeConfigData> practiceDTOs = MBJsonLoader.LoadUpgradePractice();

        foreach (var dto in habitDTOs)
        {
            MBUpgradeRuntimeData runtimeData = new MBUpgradeRuntimeData(ScriptableObject.CreateInstance<MBHabitUpgradeData>(), dto);
            _practiceUpgradeList.Add(runtimeData);
        }

        foreach (var dto in practiceDTOs)
        {
            MBUpgradeRuntimeData runtimeData = new MBUpgradeRuntimeData(ScriptableObject.CreateInstance<MBPracticeUpgradeData>(), dto);
            _habitUpgradeList.Add(runtimeData);
        }

        Debug.Log($"[MBUpgradeList] JSON 파싱: {habitDTOs.Count} + {practiceDTOs.Count} 업그레이드 불러옴.");
    }

    private void LoadUpgradeDataFromSO()
    {
        MBUpgradeData[] upgrades = Resources.LoadAll<MBUpgradeData>(MBResourcesPathes.UpgradeList);

        foreach (var upgrade in upgrades)
        {
            if( upgrade is MBHabitUpgradeData habitUpgrade)
            {
                _habitUpgradeList.Add(new MBUpgradeRuntimeData(habitUpgrade));
            }
            else if (upgrade is MBPracticeUpgradeData practiceUpgrade)
            {
                _practiceUpgradeList.Add(new MBUpgradeRuntimeData(practiceUpgrade));
            }
        }

        Debug.Log($"[MBUpgradeList] SO 파싱: {upgrades.Length} 업그레이드 불러옴.");
    }
}
