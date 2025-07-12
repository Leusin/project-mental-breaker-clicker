using System;
using UnityEngine;

/// <summary>
/// 런타임에서 사용되는 업그레이드 데이터
/// 변하지 않는 데이터와 런타임에 저장해야할 데이터 구분
/// </summary>
public class MBUpgradeRuntimeData
{
    public readonly MBUpgradeData data;

    public MBUpgradeRuntimeData(MBUpgradeData upgradeData, MBUpgradeConfigData dto = null)
    {
        data = upgradeData;

        if (dto != null)
        {
            upgradeData.upgradeId = dto.upgradeId;
            upgradeData.upgradeName = dto.upgradeName;
            upgradeData.description = dto.description;
            upgradeData.baseEffectValue = dto.baseEffect;
            upgradeData.effectPerLevel = dto.perLevel;
            upgradeData.baseCost = dto.baseCost;
            upgradeData.costMultiplier = dto.costMultiplier;
            upgradeData.flavorText = dto.flavorText;
        }
    }

    public int Level
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.GetUpgradeLevelKey(data)))
            {
                int loaded = PlayerPrefs.GetInt(MBPlayerPrefKeys.GetUpgradeLevelKey(data));
                return loaded;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetInt(MBPlayerPrefKeys.GetUpgradeLevelKey(data), value);
        }
    }

    // TEMP
    public bool IsPurchased => Level > 0;

    public float CurrentEffect => data.baseEffectValue + Level * data.effectPerLevel;
    public long CurrentCost => (long)(data.baseCost * Mathf.Pow(data.costMultiplier, Level));
}