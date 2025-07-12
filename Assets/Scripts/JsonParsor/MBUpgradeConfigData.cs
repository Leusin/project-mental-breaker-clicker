using System;

[Serializable]
public class MBUpgradeConfigData
{
    public string upgradeId;
    public string upgradeName;
    public string description;
    public float baseEffect;
    public float perLevel;
    public long baseCost;
    public float costMultiplier;
    public string flavorText;
}