using UnityEngine;

[CreateAssetMenu(fileName = "PracticeUpgrade", menuName = "MB/Upgrade/Practice")]
public class MBPracticeUpgradeData : MBUpgradeData
{
    public override string GetUpgradeCategory() => "실천";
}
