using UnityEngine;
using System;

public enum MBBreathState
{
    Charging,
    Discharging
}

[Serializable]
public class MBBreatheData
{
    [HideInInspector]
    public float currentPoint = 0f;
    public float initDuration = 6f;
    private long basePerBreath = 1; // 한 번 호흡할 떄 획득히는 포인트

    [HideInInspector]
    public MBBreathState state = MBBreathState.Charging;

    public float Duration
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.BreatheDuration))
            {
                return PlayerPrefs.GetFloat(MBPlayerPrefKeys.BreatheDuration);
            }
            else
            {
                return initDuration;
            }
        }
        set
        {
            PlayerPrefs.SetFloat(MBPlayerPrefKeys.BreatheDuration, value);
        }
    }

    public float MaxPoint => Duration;
    public float HalfDuration => Duration / 2f;

    public long PerBreath
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.PerBreath))
            {
                return basePerBreath + long.Parse(PlayerPrefs.GetString(MBPlayerPrefKeys.PerBreath));
            }
            else
            {
                return basePerBreath;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.PerBreath, value.ToString());
        }
    }
}
