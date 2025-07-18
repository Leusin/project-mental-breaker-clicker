
// 게임에 저장할 데이터의 키를 상수로 보관함
public static class MBPlayerPrefKeys
{
    // Breathe Section
    public const string BreatheDuration = "BreatheDuration";
    public const string PerBreath = "PerBreath";
    public const string BreatheMultiplier = "BreatheMultiplier";
    public const string BreatheMoodChange = "BreatheMoodChange";

    //
    // Mental Status Section
    //
    public const string MentalPoint = "MentalPoint";
    public const string PerSec = "PerSec";
    public const string MentalLevel = "MentalLevel";
    public const string MentalMood = "MentalMood";
    public const string MentalState = "MentalState";


    //
    // Off Game Time Section
    //
    public static string LastPlayTime = "LastPlayTime";

    // Upgrade Data Section
    public static string GetUpgradeLevelKey(MBUpgradeData data)
    {
        return $"{data.upgradeId}_Level";
    }

    // GameDay Section
    public static string GameDay = "GameDay";
    public static string DayilyActionCount = "DayilyActionCount";
}