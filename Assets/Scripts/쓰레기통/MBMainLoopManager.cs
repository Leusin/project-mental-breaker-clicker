// using UnityEngine; 
// using Leusin.Tools;

// /// <summary>
// /// 게임의 메인 흐름을 관리하는 매니저.
// /// </summary>
// public class MBMainGameManager : MonoBehaviourSingleton<MBMainGameManager>
// {
//     public MBRandomEventController RandomEventController => _eventExecutor;

//     private MBRandomEventController _eventExecutor;

//     private MBDataManager _dataManager;

//     private void Start()
//     {
//         _dataManager = MBDataManager.Instance;

//         _eventExecutor = new MBRandomEventController(
//             _dataManager.GameDayTracker,
//             _dataManager.MentalStats,
//             _dataManager.RandomEventLists
//         );
//     }
// }