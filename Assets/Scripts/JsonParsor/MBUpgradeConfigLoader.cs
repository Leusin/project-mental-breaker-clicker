using System.Collections.Generic;
using UnityEngine;
using Leusin.Tools.Json;

public class MBUpgradeConfigLoader
{
    public static List<MBUpgradeConfigData> LoadHabbit()
    {
        // TODO: Json 파일 경로 상수화
        TextAsset json = Resources.Load<TextAsset>("Json/upgrades");
        return JsonUtilityWrapper.FromJsonList<MBUpgradeConfigData>(json.text);
    }
    public static List<MBUpgradeConfigData> LoadPractice()
    {
        // TODO: Json 파일 경로 상수화
        TextAsset json = Resources.Load<TextAsset>("Json/upgrades");
        return JsonUtilityWrapper.FromJsonList<MBUpgradeConfigData>(json.text);
    }
}