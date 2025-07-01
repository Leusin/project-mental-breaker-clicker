
// 게임에 저장할 데이터의 키를 상수로 보관함
public static class CGPlayerPrefKeys
{
    public const string Point = "Point";
    public const string PerClick = "PerClick";

    //
    // Upgrade Button Section
    //

    public const string UpgradeButton = "UpgradeButton";

    public static string GetLevelKey(CGUpgradeButton inUpgrade)
    {
        return $"{UpgradeButton}_{inUpgrade.upgradeName}_level";
    }

    public static string GetPointbyUpgradeKey(CGUpgradeButton inUpgrade)
    {
        return $"{UpgradeButton}_{inUpgrade.upgradeName}_pointByUpgrade";
    }

    public static string GetCurrentCostKey(CGUpgradeButton inUpgrade)
    {
        return $"{UpgradeButton}_{inUpgrade.upgradeName}_pointByUpgrade";
    }

    //
    // Item Button Section
    //

    public const string ItemButton = "ItemButton";

    public static string GetLevelKey(CGItemButton inItem)
    {
        return $"{ItemButton}_{inItem.itemName}_level";
    }

    public static string GetCurrentCostKey(CGItemButton inItem)
    {
        return $"{ItemButton}_{inItem.itemName}_currentCost";
    }

    public static string GetPointPerSecKey(CGItemButton inItem)
    {
        return $"{ItemButton}_{inItem.itemName}_pointPerSec";
    }

    public static string GetIsPurchased(CGItemButton inItem)
    {
        return $"{ItemButton}_{inItem.itemName}_isPurchased";
    }

    //
    // Off Game Time Section
    //
    public static string GetTimeKey()
    {
        return $"Time";
    }
}
