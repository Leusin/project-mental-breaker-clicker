using System.Collections.Generic;
using UnityEngine;

public class MBRandomEventLists
{
    public MBRandomEventData GetPositive()
    {
        if (_positiveEventPool == null || _positiveEventPool.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, _positiveEventPool.Count);
        return _positiveEventPool[index];
    }

    public MBRandomEventData GetNegative()
    {
        if (_negativeEventPool == null || _negativeEventPool.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, _negativeEventPool.Count);
        return _negativeEventPool[index];
    }

    public MBRandomEventData GetNeutral()
    {
        if (_neutralEventPool == null || _neutralEventPool.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, _neutralEventPool.Count);
        return _neutralEventPool[index];
    }

    public MBRandomEventData GetRandomEvent()
    {
        if (_positiveEventPool == null || _positiveEventPool.Count == 0)
            return null;

        int index = Random.Range(0, _positiveEventPool.Count);
        return _positiveEventPool[index];
    }

    public MBRandomEventLists()
    {
        _positiveEventPool = MBJsonLoader.LoadRandomEventsPositive();
        _negativeEventPool = MBJsonLoader.LoadRandomEventsNegative();
        _neutralEventPool = MBJsonLoader.LoadRandomEventsNeutral();

        Debug.Log($"[MBRandomEventLists] Positive: {_positiveEventPool.Count} / Negative: {_negativeEventPool.Count} / Neutral: {_neutralEventPool.Count}");
    }

    private List<MBRandomEventData> _positiveEventPool = new List<MBRandomEventData>();
    private List<MBRandomEventData> _negativeEventPool = new List<MBRandomEventData>();
    private List<MBRandomEventData> _neutralEventPool = new List<MBRandomEventData>();
}
