// Breath 를 위한 로직 컨트롤러

using DG.Tweening;

public class MBBreatheController
{
    private MBBreatheData _breath;
    private MBMentalStatData _mentalStats;
    private MBEffectManager _effectManager;

    public MBBreatheController(MBBreatheData breathData, MBMentalStatData statsData)
    {
        _breath = breathData;
        this._mentalStats = statsData;
        _effectManager = MBEffectManager.Instance;
    }

    public void StartBreathCharging()
    {
        DOTween.To(
            () => _breath.currentSliderVal,
            x => _breath.currentSliderVal = x,
            _breath.MaxPoint,
            _breath.HalfDuration
        ).SetEase(Ease.InSine)
         .OnComplete(() =>
         {
             _breath.state = MBBreathState.Idle;
         });
        
    }

    public void StartBreathDischarging()
    {
        DOTween.To(
            () => _breath.currentSliderVal,
            x => _breath.currentSliderVal = x,
            0,
            _breath.HalfDuration
        ).SetEase(Ease.OutQuad)
         .OnComplete(() =>
         {
             _breath.state = MBBreathState.Charging;
             StartBreathCharging();
         });
    }

    public void TriggerBreathe()
    {
        if (_breath.state == MBBreathState.Idle)
        {
            // XP 지급
            long gained = (long)(_breath.PerBreath * _breath.Multiplier);
            _mentalStats.MentalPoint += gained;
            _breath.state = MBBreathState.Discharging;

            // Mood 변화 트리거
            _mentalStats.Mood += _breath.MoodChange;

            // 슬라이더 연출
            StartBreathDischarging();

            // float text
            _effectManager.PlayMultipliedFloatingText(gained.ToString());
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
