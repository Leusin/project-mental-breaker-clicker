// Breath 를 위한 로직 컨트롤러

using DG.Tweening;

public class MBBreatheController
{
    private MBBreatheData _breathData;
    private MBMentalStatData _statsData;

    public MBBreatheController(MBBreatheData breathData, MBMentalStatData statsData)
    {
        _breathData = breathData;
        this._statsData = statsData;
    }

    public void StartBreathCharging()
    {
        DOTween.To(
            () => _breathData.currentSliderVal,
            x => _breathData.currentSliderVal = x,
            _breathData.MaxPoint,
            _breathData.HalfDuration
        ).SetEase(Ease.InSine)
         .OnComplete(() =>
         {
             _breathData.state = MBBreathState.Idle;
         });
        
    }

    public void StartBreathDischarging()
    {
        DOTween.To(
            () => _breathData.currentSliderVal,
            x => _breathData.currentSliderVal = x,
            0,
            _breathData.HalfDuration
        ).SetEase(Ease.OutQuad)
         .OnComplete(() =>
         {
             _breathData.state = MBBreathState.Charging;
             StartBreathCharging();
         });
    }

    public void TriggerButton()
    {
        if (_breathData.state == MBBreathState.Idle)
        {
            _statsData.MentalPoint += (long)(_breathData.PerBreath * _breathData.Multiplier); // XP 지급
            _breathData.state = MBBreathState.Discharging;
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
