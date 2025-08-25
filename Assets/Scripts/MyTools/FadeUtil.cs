using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class FadeUtil
{
    /// <summary>
    /// UI 패널을 페이드 인 시킵니다 (불투명 -> 투명).
    /// </summary>
    /// <param name="targetPanel">페이드 인 시킬 Image 컴포넌트</param>
    /// <param name="duration">페이드 인에 걸리는 시간</param>
    public static void FadeIn(Image targetPanel, float duration)
    {
        targetPanel.DOFade(0, duration);
    }

    /// <summary>
    /// 스프라이트를 페이드 인 시킵니다 (불투명 -> 투명).
    /// </summary>
    /// <param name="targetSprite">페이드 인 시킬 SpriteRenderer 컴포넌트</param>
    /// <param name="duration">페이드 인에 걸리는 시간</param>
    public static void FadeIn(SpriteRenderer targetSprite, float duration)
    {
        targetSprite.DOFade(0, duration);
    }
}