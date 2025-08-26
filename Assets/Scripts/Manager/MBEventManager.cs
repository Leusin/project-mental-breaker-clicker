using UnityEngine;
using Leusin.Tools;

public class MBEventManager : MonoBehaviourSingleton<MBEventManager>
{
    public GameObject introPrefab;

    protected override void Awake()
    {
        base.Awake();

        // 인트로 연출을 처음 보는 경우
        if (!PlayerPrefs.HasKey(MBPlayerPrefKeys.IntroPlayedKey))
        {
            introPrefab = Resources.Load<GameObject>(MBResourcesPathes.IntroCanvas);
            Instantiate(introPrefab);
        }
    }

    /*
    void Start()
    {
        // TODO PlayerPrefs 로 첫게임 여부를 확한 후 인트로 게임오브젝트와 스크립트 생성
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
