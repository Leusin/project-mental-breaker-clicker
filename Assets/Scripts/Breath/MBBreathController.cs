// Breath 를 위한 로직 컨트롤러

using UnityEngine;
using DG.Tweening;

public class MBBreathController : MonoBehaviour
{
    // TEMP : 나중에 DataController 가 데이터 할당
    public MBBreathData data = new MBBreathData();

    public void StartBreathCharging()
    {
        DOTween.To(
            () => data.currentPoint,
            x => data.currentPoint = x,
            data.MaxPoint,
            data.HalfDuration
        ).SetEase(Ease.InSine);
    }

    public void StartBreathDischarging()
    {
        DOTween.To(
            () => data.currentPoint,
            x => data.currentPoint = x,
            0,
            data.HalfDuration
        ).SetEase(Ease.OutQuad)
         .OnComplete(() =>
         {
             data.state = MBBreathState.Charging;
             StartBreathCharging();
         });
    }

    public void TriggerButton()
    {
        if (data.state == MBBreathState.Charging && data.currentPoint >= data.MaxPoint)
        {
            data.state = MBBreathState.Discharging;
            StartBreathDischarging();
        }
    }

    /*
    public void UpdateBreath()
    {
        switch (data.state)
        {
            case MBBreathState.Charging:
                data.currentPoint += Time.deltaTime * data.Speed;
                if (data.currentPoint >= data.MaxPoint)
                {
                    data.currentPoint = data.MaxPoint;
                }
                break;

            case MBBreathState.Discharging:
                data.currentPoint -= Time.deltaTime * data.Speed;
                if (data.currentPoint <= 0)
                {
                    data.currentPoint = 0;
                    data.state = MBBreathState.Charging;
                }
                break;
        }
    }
    */
}
