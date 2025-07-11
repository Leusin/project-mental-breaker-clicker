using UnityEngine;
using System;

public enum MBBreathState
{
    Charging,
    Discharging,
    Idle
}

[Serializable]
public class MBBreatheData
{
    [HideInInspector]
    public float currentSliderVal = 0f;
    public float initDuration = 6f;
    private long _initPerBreath = 1;
    private float _initMultiplier = 1.1f;

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
                return long.Parse(PlayerPrefs.GetString(MBPlayerPrefKeys.PerBreath));
            }
            else
            {
                return _initPerBreath;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.PerBreath, value.ToString());
        }
    }

    public float Multiplier
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.BreatheMultiplier))
            {
                return PlayerPrefs.GetFloat(MBPlayerPrefKeys.BreatheMultiplier);
            }
            else
            {
                return _initMultiplier;
            }
        }
        set
        {
            PlayerPrefs.SetFloat(MBPlayerPrefKeys.BreatheMultiplier, value);
        }
    }
}
