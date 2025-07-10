using UnityEngine;

[CreateAssetMenu(fileName = "PassiveUpgrade", menuName = "MB/Upgrade/Passive")]
public class MBPassiveUpgradeData : MBUpgradeData
{
    public override string GetUpgradeCategory() => "습관";
}
