using UnityEngine;
using Leusin.Tools;
using Leusin.Tools.Effects;

public class MBEffectManager : MonoBehaviourSingleton<MBEffectManager>
{
    [Header("Prefabs")]

    private Canvas _canvasWorldSpace;
    private Canvas _canvasScreenSpace;

    private GameObject _floatingTextPrefab;
    private GameObject _floatingTextPrefab_Multiplied;

    protected override void Awake()
    {
        base.Awake();
        _canvasWorldSpace = GameObject.Find("Canvas_Effect_WorldSpace").GetComponent<Canvas>();
        _canvasScreenSpace = GameObject.Find("Canvas_Effect_ScreenSpaceOverlay").GetComponent<Canvas>();
        _floatingTextPrefab = Resources.Load<GameObject>(MBResourcesPathes.FloatingTextPrefab);
        _floatingTextPrefab_Multiplied = Resources.Load<GameObject>(MBResourcesPathes.FloatingTextPrefab_Multiplied);
    }

    public void PlayFloatingText(string value)
    {
        Vector3 Pos = GetClickedWorldPos();

        GameObject go = Instantiate(_floatingTextPrefab, Pos, Quaternion.identity, _canvasWorldSpace.transform);

        FloatingTextEffect effect = go.GetComponent<FloatingTextEffect>();
        effect.Play(value, Pos);
    }

    /// <summary>
    /// Canvas Render Mode가 "Screen Space - Overlay"일 경우 Transform 이동 애니메이션이 안 먹는다.
    /// 대신 RectTransform.anchoredPosition으로 애니메이션 줘야 하는데, 지금상태도 꽤 괜찮아서 그냥 두는 중
    /// </summary>
    public void PlayMultipliedFloatingText(string value)
    {
        Vector3 Pos = Input.mousePosition;

        GameObject go = Instantiate(_floatingTextPrefab_Multiplied, Pos, Quaternion.identity, _canvasScreenSpace.transform);

        FloatingTextEffect effect = go.GetComponent<FloatingTextEffect>();
        effect.Play(value, Pos);
    }

    private Vector3 GetClickedWorldPos()
    {
        Vector3 screenPos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;

        return worldPos;
    }
}

// memo1
// 내생각에는 프리팹 별로 캔버스를 갖는것 보다 하나의 World Space 캔버스에 텍스트 프리팹을 동작시키는 게 나은 것 같음.
// 근거는 없음