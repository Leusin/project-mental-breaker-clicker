using System.Collections.Generic;
using UnityEngine;
using Leusin.Tools.Json;

public class MBJsonLoader
{
    // Upgrade Config Loader
    public static List<MBUpgradeConfigData> LoadUpgradeHabbit()
    {
        // TODO: Json 파일 경로 상수화
        TextAsset json = Resources.Load<TextAsset>("Json/upgrades");
        return JsonUtilityWrapper.FromJsonList<MBUpgradeConfigData>(json.text);
    }
    public static List<MBUpgradeConfigData> LoadUpgradePractice()
    {
        // TODO: Json 파일 경로 상수화
        TextAsset json = Resources.Load<TextAsset>("Json/upgrades");
        return JsonUtilityWrapper.FromJsonList<MBUpgradeConfigData>(json.text);
    }

    // Random Event Loader
    public static List<MBRandomEventData> LoadRandomEventsPositive()
    {
        TextAsset json = Resources.Load<TextAsset>("Json/random_events");
        return JsonUtilityWrapper.FromJsonList<MBRandomEventData>(json.text);
    }
    public static List<MBRandomEventData> LoadRandomEventsNegative()
    {
        TextAsset json = Resources.Load<TextAsset>("Json/random_events");
        return JsonUtilityWrapper.FromJsonList<MBRandomEventData>(json.text);
    }
    public static List<MBRandomEventData> LoadRandomEventsNeutral()
    {
        TextAsset json = Resources.Load<TextAsset>("Json/random_events");
        return JsonUtilityWrapper.FromJsonList<MBRandomEventData>(json.text);
    }
}