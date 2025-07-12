using System;
using System.Collections.Generic;

[Serializable]
public class MBRandomEventData
{
    public string eventId;
    public string title;
    public string description;

    public List<MBEventChoice> choices;
}

[Serializable]
public class MBEventChoice
{
    public string text;
    public int moodDelta;
    public long mpDelta;
    public string resultText;

    public float requiredMoodMin = -999f;
    public float requiredMoodMax = 999f;
}
