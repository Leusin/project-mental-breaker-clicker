// Breath 를 위한 데이터 클래스

using System;

public enum MBBreathState
{
    Charging,
    Discharging
}

[Serializable]
public class MBBreathData
{
    public float currentPoint = 0f;
    public float duration = 6f;
    public MBBreathState state = MBBreathState.Charging;

    public float MaxPoint => duration;
    public float HalfDuration => duration / 2f;
}
