using UnityEngine;

[CreateAssetMenu(fileName = "ActiveUpgrade", menuName = "MB/Upgrade/Active")]
public class MBActiveUpgradeData : MBUpgradeData
{
    public override string GetUpgradeCategory() => "실천";
}
