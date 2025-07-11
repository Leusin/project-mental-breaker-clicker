using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Leusin.Tools.Effects
{
    public class FloatingTextEffect : MonoBehaviour
    {
        public TMP_Text text;
        public CanvasGroup canvasGroup;

        public void Play(string value, Vector3 worldPos)
        {
            text.text = value;
            transform.position = worldPos;

            // 초기 위치 & 투명도
            transform.localScale = Vector3.one * 1.0f;

            // 애니메이션
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DOMoveY(worldPos.y + 1f, 0.8f).SetEase(Ease.OutQuad));
            seq.Join(canvasGroup.DOFade(0f, 1f));
            seq.OnComplete(() => Destroy(gameObject));
        }
    }
}