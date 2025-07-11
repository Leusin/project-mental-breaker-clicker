
// 게임에 저장할 데이터의 키를 상수로 보관함
public static class MBPlayerPrefKeys
{
    // Breathe Section
    public const string BreatheDuration = "BreatheDuration";
    public const string PerBreath = "PerBreath";
    public const string BreatheMultiplier = "BreatheMultiplier";

    //
    // Mental Status Section
    //
    public const string MentalPoint = "MentalPoint";
    public const string MentalLevel = "MentalLevel";
    public const string MentalMood = "MentalMood";
    public const string MentalState = "MentalState";


    //
    // Off Game Time Section
    //
    public static string GetTimeKey()
    {
        return $"Time";
    }

    // Upgrade Data Section
    public static string GetUpgradeLevelKey(MBUpgradeData data)
    {
        return $"{data.upgradeId}_Level";
    }
}
