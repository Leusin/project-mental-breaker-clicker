// using System.Collections.Generic;

// /// <summary>
// /// 클릭 처리 로직 처리 (MP 소모, 레벨업 등)
// /// </summary>
// public class MBUpgradeController
// {
//     private MBUpgradeListManager _upgradeManager;
//     private MBDataManager _dataManager;

//     public MBUpgradeController(MBUpgradeListManager manager, MBDataManager dataManager)
//     {
//         _upgradeManager = manager;
//         _dataManager = dataManager;
//     }

//     public List<MBUpgradeRuntimeData> GetAllUpgrades()
//     {
//         return _upgradeManager.upgradeList;
//     }

//     public bool TryPurchaseUpgrade(MBUpgradeRuntimeData upgrade)
//     {
//         long cost = upgrade.CurrentCost;
//         if (_dataManager.MentalStats.MentalPoint >= cost)
//         {
//             _dataManager.MentalStats.MentalPoint -= cost;
//             upgrade.Level++;

//             UpdateBreathBonus();

//             return true;
//         }
//         return false;
//     }
    
//     private void UpdateBreathBonus()
//     {
//         long baseValue = _dataManager.BreathData.basePerBreath;
//         long bonus = _upgradeManager.GetClickBonus();

//             _dataManager.BreathData.PerBreath = baseValue + bonus;
// }
// }
