using UnityEngine;

public abstract class MBUpgradeData : ScriptableObject
{
    public string upgradeId;
    public string upgradeName;
    public string description;

    public float baseEffectValue;
    public float effectPerLevel;

    public long baseCost;
    public float costMultiplier;
    public string unlockConditionText;

    [TextArea]
    public string flavorText;

    public abstract string GetUpgradeCategory();  // 예: "습관", "실천"
}
