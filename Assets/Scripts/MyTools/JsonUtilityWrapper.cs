using System.Collections.Generic;
using UnityEngine;

namespace Leusin.Tools.Json
{
    public static class JsonUtilityWrapper
    {
        [System.Serializable]
        private class Wrapper<T>
        {
            public List<T> items;
        }

        public static List<T> FromJsonList<T>(string json)
        {
            string wrapped = "{\"items\":" + json + "}";
            return JsonUtility.FromJson<Wrapper<T>>(wrapped).items;
        }
    }

}

/*

Unity의 JsonUtility.FromJson<T>()는 리스트(배열)를 직접 파싱할 수 없음.

- 예:
[
  { "upgradeId": "sunlight", "upgradeName": "햇빛 쬐기" },
  { "upgradeId": "cleanroom", "upgradeName": "방 청소" }
]

이걸 JsonUtility.FromJson<List<MBUpgradeConfigData>>() 로 호출하면 안 됨. 에러남.

- 사용 예:
var upgrades = JsonUtilityWrapper.FromJsonList<MBUpgradeConfigData>(jsonText);

*/