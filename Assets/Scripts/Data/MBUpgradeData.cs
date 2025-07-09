using UnityEngine;

public enum MBUpgradeType
{
    Passive, // 습관
    Active // 실천
}

public enum StatEffectType
{
    None,
    MPPerClick,
    MPPerSec,
    Mood,
    SelfEsteem
}

[CreateAssetMenu(fileName = "Upgrade", menuName = "MB/UpgradeData")]
public class MBUpgradeData : ScriptableObject
{
    public string upgradeId;
    public string upgradeName;
    public string description;

    public MBUpgradeType type;
    public StatEffectType effectType;
    public float baseEffectValue;
    public float effectPerLevel;      // 각 레벨당 추가 보정

    public long baseCost;
    public float costMultiplier;
    public string unlockConditionText;

    [TextArea]
    public string flavorText;
}
