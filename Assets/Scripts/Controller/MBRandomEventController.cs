using System;
using UnityEngine;

public class MBRandomEventController
{
    public event Action<MBRandomEventData> OnShowEvent;

    public MBRandomEventController(MBGameDayTracker dayTracker, MBMentalStatData stats, MBRandomEventLists eventLists)
    {
        _dayTracker = dayTracker;
        _stats = stats;
        _eventLists = eventLists;

        _dayTracker.OnNewDay += TryTriggerEvent;
    }

    public void ApplyChoiceResult(MBEventChoice choice)
    {
        _stats.Mood += choice.moodDelta;
        _stats.MentalPoint += choice.mpDelta;

        Debug.Log($"[RandomEventController] 선택 결과 반영됨: {choice.text} ");
    }

    private void TryTriggerEvent(int inGameDay)
    {
        float mood = _stats.Mood;
        MBRandomEventData selectedEvent = null;

        float rand = UnityEngine.Random.value;
        Debug.Log($"[RandomEventController] Day {inGameDay} - Mood: {mood}, Random: {rand}");

        // TEMP
        // 무드에 따라 확률 조정
        if (mood >= 50)
        {
            if (rand < 0.6f) selectedEvent = _eventLists.GetPositive();
            else selectedEvent = _eventLists.GetNeutral();
        }
        else if (mood <= -30)
        {
            if (rand < 0.5f) selectedEvent = _eventLists.GetNegative();
            else selectedEvent = _eventLists.GetNeutral();
        }
        else
        {
            if (rand < 0.3f) selectedEvent = _eventLists.GetPositive();
            else if (rand < 0.7f) selectedEvent = _eventLists.GetNeutral();
            else selectedEvent = _eventLists.GetNegative();
        }

        if (selectedEvent != null)
        {
            Debug.Log($"[RandomEventController] 이벤트 발생: {selectedEvent.title}");
            OnShowEvent?.Invoke(selectedEvent);
        }
    }

    private float _positiveChance = 0.3f;
    private float _neutralChance = 0.4f;
    private float _negativeChance = 0.3f;

    private MBGameDayTracker _dayTracker;
    private MBMentalStatData _stats;
    private MBRandomEventLists _eventLists;
}