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
                return _initDuration;
            }
        }
        set
        {
            PlayerPrefs.SetFloat(MBPlayerPrefKeys.BreatheDuration, value);
        }
    }

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
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.PerBreath, value.ToString());
        }
    }

    public float MaxPoint => Duration;
    public float HalfDuration => Duration / 2f;

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

    public float MoodChange
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.BreatheMoodChange))
            {
                return PlayerPrefs.GetFloat(MBPlayerPrefKeys.BreatheMoodChange);
            }
            else
            {
                return _initMoodChange;
            }
        }
        set
        {
            PlayerPrefs.SetFloat(MBPlayerPrefKeys.BreatheMoodChange, value);
        }
    }


    private float _initDuration = 6f;
    private float _initMultiplier = 1.1f;
    private float _initMoodChange = 0.2f;
}
