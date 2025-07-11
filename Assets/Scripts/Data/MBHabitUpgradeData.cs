using UnityEngine;

[CreateAssetMenu(fileName = "PassiveUpgrade", menuName = "MB/Upgrade/Passive")]
public class MBHabitUpgradeData : MBUpgradeData
{
    public override string GetUpgradeCategory() => "습관";
}
